using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{
  /// <summary>
  /// 
  /// <summary>
  public class StoreSingleton
  {
    private readonly FileRepository _fileRepository = new FileRepository();
    private readonly PizzaBoxContext _context = new PizzaBoxContext();
    private static StoreSingleton _instance;
    private const string _filePath = @"data/store.xml";

    public List<AStore> Stores { get; }
    public static StoreSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new StoreSingleton();
        }

        return _instance;
      }
    }

    private StoreSingleton()
    {
      if (Stores == null)
      {
        // Stores = _fileRepository.ReadFromFile<List<AStore>>(_filePath);
        Stores = _context.Stores.ToList();
      }
    }
  }
}