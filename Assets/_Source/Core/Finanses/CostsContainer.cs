using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace Core
{
  public class CostsContainer
  {
    private readonly TextAsset _costsAsset;
    public CostsContainer(TextAsset asset)
    {
      _costsAsset = asset;
      Costs = ReadCosts();
    }

    public Dictionary<int, int> Costs { get; private set; }

    private Dictionary<int, int> ReadCosts()
    {
      string serializedObject = _costsAsset.text;
      return JsonConvert.DeserializeObject<Dictionary<int, int>>(serializedObject);
    }
  }
}