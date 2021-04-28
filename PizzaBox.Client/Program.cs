using System;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Client.Singletons;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;
using System.Collections.Generic;

namespace PizzaBox.Client
{
  public class Program
  {
    private static readonly PizzaBoxContext _context = new PizzaBoxContext();
    private static readonly CustomerSingleton _customerSingleton = CustomerSingleton.Instance(_context);
    private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance(_context);
    private static readonly PizzaSingleton _pizzaSingleton = PizzaSingleton.Instance(_context);
    private static readonly OrderRepository _orderRepository = new OrderRepository(_context);

    /// <summary>
    /// 
    /// </summary>
    private static void Main()
    {
      Run();
    }

    /// <summary>
    /// 
    /// </summary>
    private static void Run()
    {
      var order = new Order();

      Console.WriteLine("PizzaBox. Online, and ready to serve");
      Console.WriteLine("Who are we serving today? Press 0 for new customer");
      PrintListToScreen(_customerSingleton.Customers);

      order.Customer = SelectCustomer();
      order.Store = SelectStore();
      order.Pizza = SelectPizza();

      PrintOrder(order);

      _orderRepository.Create(order);
    }

    /// <summary>
    /// 
    /// </summary>
    private static void PrintOrder(Order order)
    {
      Console.WriteLine($"\nYour order placed at {order.Store} is: {order.Pizza}");
      Console.WriteLine($"Your total on this order is: {order.TotalCost}");
    }

    /// <summary>
    /// 
    /// </summary>
    private static void PrintStoreList()
    {
      Console.WriteLine("\nWhat store are you ordering from?");
      var index = 0;

      foreach (var item in _storeSingleton.Stores)
      {
        Console.WriteLine($"{++index} - {item}");
      }
    }

    /// <summary>
    /// 
    /// </summary>
    private static void PrintPizzaList()
    {
      var index = 0;

      Console.WriteLine("\nWhat pizza would you like to order?");

      foreach (var item in _pizzaSingleton.Pizzas)
      {
        Console.WriteLine($"{++index} - {item}");
      }
    }

    private static void PrintListToScreen(IEnumerable<object> items)
    {
      var index = 0;

      foreach (var item in items)
      {
        Console.WriteLine($"{++index} - {item}");
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private static Customer SelectCustomer()
    {
      var validInput = Console.ReadLine();
      var customer = new Customer();
      // var validInput = int.TryParse(Console.ReadLine(), out int input);

      if (!int.TryParse(validInput, out int input))
      {
        return null;
      }
      switch (Convert.ToInt32(validInput))
      {
        case 0:
          customer.Name = AddCustomer();
          break;
        default:
          customer = _customerSingleton.Customers[input - 1];
          break;
      }
      PrintStoreList();



      return customer;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private static AStore SelectStore()
    {
      var validInput = int.TryParse(Console.ReadLine(), out int input);

      if (!validInput)
      {
        return null;
      }

      PrintPizzaList();

      return _storeSingleton.Stores[input - 1];
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private static APizza SelectPizza()
    {
      var validInput = int.TryParse(Console.ReadLine(), out int input);

      if (!validInput)
      {
        return null;
      }

      var pizza = _pizzaSingleton.Pizzas[input - 1];


      return pizza;
    }

    private static string AddCustomer()
    {
      Console.WriteLine("Create an account!");
      return Console.ReadLine();
    }
  }
}