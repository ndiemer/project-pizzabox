using System;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Client.Singletons;


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

        private static void Run()
        {
            var order = new Order();

            Console.WriteLine("PizzaBox. Online, and ready to serve");
            PrintStoreList();

            order.Customer = new Customer();
            order.Store = SelectStore();
            order.Pizza = SelectPizza();
        }

        private static void PrintOrder(APizza pizza)
        {
            Console.WriteLine($"Your order is: {pizza.Name}");
        }

        private static void PrintStoreList()
        {
            var index = 0;

            foreach (var item in _storeSingleton.Stores)
            {
                Console.WriteLine($"{++index} - {item}");
            }
        }

        private static void PrintPizzaList()
        {
            var index = 0;

            foreach (var item in _pizzaSingleton.Pizzas)
            {
                Console.WriteLine($"{++index} - {item.Name}");
            }
        }

        private static AStore SelectStore()
        {
            var input = int.Parse(Console.ReadLine());

            PrintPizzaList();

            return _storeSingleton.Stores[input - 1];
        }

        private static APizza SelectPizza()
        {
            var input = int.Parse(Console.ReadLine());
            var pizza = _pizzaSingleton.Pizzas[input - 1];

            PrintOrder(pizza);

            return pizza;
        }
    }
}