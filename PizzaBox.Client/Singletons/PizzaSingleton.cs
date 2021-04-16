using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models.Pizzas;

namespace PizzaBox.Client.Singletons
{
    public class PizzaSingleton
    {
        private static readonly PizzaSingleton _instance;
        public List<APizza> Pizzas { get; }

        public static PizzaSingleton Instance
        {
            get
            {
                if (_instance ==null)
                {
                   return new PizzaSingleton(); 
                }

                return _instance;
            }
        }

        private PizzaSingleton()
        {
            Pizzas = new List<APizza>()
            {
                new CustomPizza(),
                new MeatPizza(),
                new SupremePizza()
            };
        }
    }
}