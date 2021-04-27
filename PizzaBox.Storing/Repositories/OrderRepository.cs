using System.Linq;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Repositories
{
  public class OrderRepository
  {
    private readonly PizzaBoxContext _context;
    public OrderRepository(PizzaBoxContext context)
    {
      _context = context;
    }

    public void Create(Order order)
    {
      order.Store = _context.Stores.FirstOrDefault(s => s.Name == order.Store.Name);
      order.Pizza = _context.Pizzas.FirstOrDefault(p => p == order.Pizza);
      _context.Orders.Add(order);
      _context.SaveChanges();
    }
  }
}