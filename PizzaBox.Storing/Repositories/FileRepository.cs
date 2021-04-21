using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Storing.Repositories
{
  public class FileRepository
  {

    public T ReadFromFile<T>(string filePath) where T : class
    {
      try
      {
        var reader = new StreamReader(filePath);
        var xml = new XmlSerializer(typeof(T));

        var results = xml.Deserialize(reader) as T;
        return results;
      }
      catch
      {
        return null;
      }

    }

    public bool WriteToFile<T>(string filePath, T items)
    {
      try
      {
        var writer = new StreamWriter(filePath);
        var xml = new XmlSerializer(typeof(T));

        xml.Serialize(writer, items);
        return true;
      }
      catch
      {
        return false;
      }
    }
  }
}