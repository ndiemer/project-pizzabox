using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models.Pizzas
{
  /// <summary>
  /// 
  /// </summary>
  public class SupremePizza : APizza
  {
    /// <summary>
    /// 
    /// </summary>
    public override void AddCrust(Crust crust)
    {
      Crust = new Crust() { Name = "Thin", Price = 4M };
    }

    /// <summary>
    /// 
    /// </summary>
    public override void AddSize(Size size)
    {
      Size = new Size() { Name = "Medium", Price = 10M };
    }

    /// <summary>
    /// 
    /// </summary>
    public override void AddToppings(params Topping[] toppings)
    {
      Toppings = new List<Topping>()
      {
        new Topping() { Name = "Pepperoni", Price = 3M },
        new Topping() { Name = "Sausage", Price = 3M },
        new Topping() { Name = "Green Peppers", Price = 1M },
        new Topping() { Name = "Black Olives", Price = 1M },
      };
    }
  }
}