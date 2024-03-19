using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Core
{
  public class FoodShop 
  {
    [Space(15)] [Inject] private Wallet _wallet;
    [Inject] private FoodInventory _inventory;
    [Inject] private List<FoodItem> _sellPositions;
    [Inject] private readonly CostsContainer _container;
    
    public bool TrySellFood(int goodId)
    {
      if (!_wallet.TryWriteOffMoney(_container.Costs[goodId]))
        return false;

      _inventory.AddItem(_sellPositions.Find(position => position.Id == goodId));
      return true;
    }

    public (FoodItem, int) GetFood(int id)
    {
      return (_sellPositions.FirstOrDefault(x => x.Id == id), _container.Costs[id]);
    }
  }
}