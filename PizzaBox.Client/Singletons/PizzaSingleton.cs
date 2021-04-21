using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{
  public class PizzaSingleton
  {
    private readonly FileRepository _fileRepository = new FileRepository();
    private readonly PizzaBoxContext _context = new PizzaBoxContext();
    private static PizzaSingleton _instance;
    private const string _filePath = @"data/pizzas.xml";

    public List<APizza> Pizzas { get; }
    public static PizzaSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new PizzaSingleton();
        }

        return _instance;
      }
    }

    /// <summary>
    /// Constructor
    /// </summary>
    private PizzaSingleton()
    {
      if (Pizzas == null)
      {
        Pizzas = _fileRepository.ReadFromFile<List<APizza>>(_filePath);
        //Pizzas = _context.Pizzas.ToList();
      }
    }
  }
}