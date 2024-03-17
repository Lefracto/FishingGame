using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace Core
{
  public class CostsContainer
  {
    public CostsContainer(string path)
    {
      _configPath = path;
      Costs = ReadCosts();
    }

    private readonly string _configPath;
    public Dictionary<int, int> Costs { get; private set; }

    private Dictionary<int, int> ReadCosts()
    {
      string serializedObject = File.ReadAllText(_configPath);
      return JsonConvert.DeserializeObject<Dictionary<int, int>>(serializedObject);
    }
  }
}