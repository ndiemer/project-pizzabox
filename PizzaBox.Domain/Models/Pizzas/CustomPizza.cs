using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models.Pizzas
{
  /// <summary>
  /// 
  /// </summary>
  public class CustomPizza : APizza
  {
    /// <summary>
    /// 
    /// </summary>
    public override void AddCrust(Crust crust)
    {
      Crust = crust ?? new Crust() { Name = "Original" };
    }

    /// <summary>
    /// 
    /// </summary>
    public override void AddSize(Size size)
    {
      Size = size ?? new Size() { Name = "Medium" };
    }

    /// <summary>
    /// 
    /// </summary>
    public override void AddToppings(params Topping[] toppings)
    {
      Toppings = new List<Topping>()
      {
        new Topping() { Name = "Mozzarella" },
        new Topping() { Name = "Marinara" }
      };
    }
  }
}