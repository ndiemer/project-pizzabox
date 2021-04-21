using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.Pizzas;

namespace PizzaBox.Domain.Abstracts
{
  /// <summary>
  /// 
  /// </summary>
  [XmlInclude(typeof(CustomPizza))]
  [XmlInclude(typeof(MeatPizza))]
  [XmlInclude(typeof(SupremePizza))]
  public abstract class APizza : AModel
  {
    public Crust Crust { get; set; }
    public Size Size { get; set; }
    public List<Topping> Toppings { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public APizza()
    {
      Factory();
    }

    /// <summary>
    /// 
    /// </summary>
    protected virtual void Factory()
    {
      AddCrust();
      AddSize();
      AddToppings();
    }

    /// <summary>
    /// 
    /// </summary>
    protected virtual void AddCrust() { }

    /// <summary>
    /// 
    /// </summary>
    protected virtual void AddSize() { }

    /// <summary>
    /// 
    /// </summary>
    protected abstract void AddToppings();

    /// <summary>
    /// 
    /// </summary>
    public override string ToString()
    {
      var stringBuilder = new StringBuilder();
      var seperator = ", ";

      foreach (var item in Toppings)
      {
        stringBuilder.Append($"{item}{seperator}");
      }

      return $"{Crust} - {Size} - {stringBuilder.ToString().TrimEnd(seperator.ToCharArray())}";
    }
  }
}
