using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.Pizzas;
using Xunit;

namespace PizzaBox.Testing.Tests
{
  public class PizzaTests
  {
    [Fact]
    public void Test_MeatPizza()
    {
      var sut = new MeatPizza();

      Assert.NotNull(sut.Crust);
      Assert.NotNull(sut.Size);
      Assert.NotNull(sut.Toppings);
    }

    [Fact]
    public void Test_SupremePizza()
    {
      var sut = new SupremePizza();

      Assert.NotNull(sut.Crust);
      Assert.NotNull(sut.Size);
      Assert.NotNull(sut.Toppings);
    }

    [Fact]
    public void Test_CustomPizza()
    {
      var sut = new CustomPizza();

      Assert.NotNull(sut.Crust);
      Assert.NotNull(sut.Size);
      Assert.NotNull(sut.Toppings);
    }

    [Fact]
    public void Test_CrustPrice()
    {
      var sut = new Crust() { Price = 10M };
      Assert.Equal(10M, sut.Price);
    }
  }
}