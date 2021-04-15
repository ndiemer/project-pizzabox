using System.Collections.Generic;
using System;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.Stores;
using PizzaBox.Domain.Models.Pizzas;


namespace PizzaBox.Client
{
    public class Program
    {
        private static readonly List<AStore> _stores = new List<AStore>()
        {
            new ChicagoStore(),
            new NewYorkStore()
        };
        private static readonly List<APizza> _pizzas = new List<APizza>()
        {
            new CustomPizza(),
            new MeatPizza(),
            new SupremePizza(),

        };

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

        }

        private static void PrintStoreList()
        {
            var index = 0;

            foreach ( var item in _stores)
            {
                Console.WriteLine($"{++index} - {item}");
            }
        }

        private static void PrintPizzaList()
        {
            var index = 0;

            foreach ( var item in _pizzas)
            {
                Console.WriteLine($"{++index} - {item}");
            }
        }

        private static AStore SelectStore()
        {
            var input = int.Parse(Console.ReadLine());

            PrintPizzaList();

            return _stores[input - 1];
        }
    }
}