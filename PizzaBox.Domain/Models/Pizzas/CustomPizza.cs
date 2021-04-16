using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models.Pizzas
{
    public class CustomPizza : APizza
    {
        public CustomPizza()
        {
            Name = "Custom Order Pizza";
        }
    }
}