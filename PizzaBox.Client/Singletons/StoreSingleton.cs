using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
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
    private readonly PizzaBoxContext _context;
    private static StoreSingleton _instance;
    private const string _filePath = @"data/store.xml";

    public List<AStore> Stores { get; }

    private StoreSingleton(PizzaBoxContext context)
    {
      //_context.Stores.AddRange(_fileRepository.ReadFromFile<List<AStore>>(_filePath));
      //_context.SaveChanges();
      _context = context;
      Stores = _context.Stores.ToList();
    }

    public static StoreSingleton Instance(PizzaBoxContext context)
    {
      if (_instance == null)
      {
        _instance = new StoreSingleton(context);
      }

      return _instance;
    }


    // public IEnumerable<AStore> ViewOrders(AStore store)
    // {
    //   var orders = _context.Stores
    //                 .Include(s => s.Orders)
    //                 .ThenInclude(o => o.Pizza)
    //                 .Where(s => s.Name == store.Name); // LINQ = lang integrated query
    //   var orders2 = from r in _context.Stores
    //                   //join ro in _context.Orders on r.EntityId == ro.StoreEntityID
    //                 where r.Name == store.Name
    //                 select r;
    //   var orders3 = _context.Stores.FirstOrDefault(s => s.Name == store.Name);
    //   _context.Entry<AStore>(store).Collection<Order>(s => s.Orders).Load();
    //   return orders.ToList();
    // }
  }
}