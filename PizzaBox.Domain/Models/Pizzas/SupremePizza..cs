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
      Crust = new Crust() { Name = "Thin" };
    }

    /// <summary>
    /// 
    /// </summary>
    public override void AddSize(Size size)
    {
      Size = new Size() { Name = "Medium" };
    }

    /// <summary>
    /// 
    /// </summary>
    public override void AddToppings(params Topping[] toppings)
    {
      Toppings = new List<Topping>()
      {
        new Topping() { Name = "Pepperoni" },
        new Topping() { Name = "Sausage" },
        new Topping() { Name = "Green Peppers" },
        new Topping() { Name = "Black Olives" },
      };
    }
  }
}