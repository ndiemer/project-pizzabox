using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models.Pizzas
{
  /// <summary>
  /// 
  /// </summary>
  public class MeatPizza : APizza
  {
    /// <summary>
    /// 
    /// </summary>
    public override void AddCrust(Crust crust)
    {
      Crust = new Crust() { Name = "Original" };
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
        new Topping() { Name = "Mozzarella", Price = 2M },
        new Topping() { Name = "Bacon", Price = 3M },
        new Topping() { Name = "Pepperoni", Price = 3M },
        new Topping() { Name = "Ham", Price = 3M },
        new Topping() { Name = "Sausage", Price = 3M },
      };
    }
  }
}