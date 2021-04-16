using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{
    /// <summary>
    /// 
    /// <summary>
    public class StoreSingleton
    {
        private const string _filePath = @"store.xml";
        private readonly FileRepository _fr = new FileRepository();
        private static readonly StoreSingleton _instance;
        public List<AStore> Stores { get; }

        public static StoreSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    return new StoreSingleton();
                }

                return _instance;
            }
        }

        private StoreSingleton()
        {
            if (Stores == null)
            {
                Stores = _fr.ReadFromFile(_filePath);
            }

            Stores = _fr.ReadFromFile(_filePath);
        }
    }
}