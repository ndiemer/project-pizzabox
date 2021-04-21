using System;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Client.Singletons;
using PizzaBox.Storing;

namespace PizzaBox.Client
{
  public class Program
  {
    /// <summary>
    /// 
    /// </summary>
    private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance;
    private static readonly PizzaSingleton _pizzaSingleton = PizzaSingleton.Instance;

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
      PrintStoreList();

      order.Customer = new Customer();
      order.Store = SelectStore();
      order.Pizza = SelectPizza();
    }

    /// <summary>
    /// 
    /// </summary>
    private static void PrintOrder(APizza pizza)
    {
      Console.WriteLine($"Your order is: {pizza}");
    }

    /// <summary>
    /// 
    /// </summary>
    private static void PrintStoreList()
    {
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

      foreach (var item in _pizzaSingleton.Pizzas)
      {
        Console.WriteLine($"{++index} - {item}");
      }
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

      PrintOrder(pizza);

      return pizza;
    }
  }
}