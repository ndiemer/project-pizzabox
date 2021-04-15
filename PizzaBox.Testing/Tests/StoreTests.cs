using PizzaBox.Domain.Models;
using Xunit;

namespace PizzaBox.Testing.Tests
{
    public class StoreTests
    {
        [Fact]
        public void Test_ChicagoStore()
        {
            // arrange
            var sut = new ChicagoStore(); //subject under test

            // act
            var actual = sut.Name;

            // assert
            Assert.True(actual == "ChicagoStore");
            Assert.True(sut.ToString() == actual);
        }

        [Fact]
        public void Test_NewYorkStore()
        {
            var sut = new NewYorkStore();

            Assert.True(sut.Name == "NewYorkStore");
        }
    }
}