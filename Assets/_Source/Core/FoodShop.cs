using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using System.IO;

namespace Core
{
  public class FoodShop : MonoBehaviour
  {
    [SerializeField] private string _configFileName;

    [Space(15)] [SerializeField] private Wallet _wallet;
    [SerializeField] private FoodInventory _inventory;
    [SerializeField] private List<FoodItem> _sellPositions;
    [SerializeField] private string _configPath;
    private CostsContainer _container;
    
    void Start()
    {
      _container = new CostsContainer(_configPath);
    }
    
    public bool TrySellFood(int goodId)
    {
      if (!_wallet.TryWriteOffMoney(_container.Costs[goodId]))
        return false;

      _inventory.AddItem(_sellPositions.Find(position => position.Id == goodId));
      return true;
    }
  }
}