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
    // public long CrustEntityId { get; set; }
    public Size Size { get; set; }
    // public long SizeEntityId { get; set; }
    public List<Topping> Toppings { get; set; }

    /// <summary>
    /// 
    /// </summary>
    protected APizza()
    {
      Factory();
    }

    /// <summary>
    /// 
    /// </summary>
    public virtual void Factory()
    {
      AddCrust();
      AddSize();
      AddToppings();
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract void AddCrust(Crust crust = null);

    /// <summary>
    /// 
    /// </summary>
    public abstract void AddSize(Size size = null);

    /// <summary>
    /// 
    /// </summary>
    public abstract void AddToppings(params Topping[] toppings);

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
