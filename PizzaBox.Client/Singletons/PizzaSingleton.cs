using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Storing;

namespace PizzaBox.Client.Singletons
{
  public class PizzaSingleton
  {
    private static PizzaSingleton _instance;
    private readonly PizzaBoxContext _context;

    public List<APizza> Pizzas { get; }

    /// <summary>
    /// Constructor
    /// </summary>
    private PizzaSingleton(PizzaBoxContext context)
    {
      _context = context;

      Pizzas = _context.Pizzas.ToList();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public static PizzaSingleton Instance(PizzaBoxContext context)
    {
      if (_instance == null)
      {
        _instance = new PizzaSingleton(context);
      }

      return _instance;
    }
  }
}