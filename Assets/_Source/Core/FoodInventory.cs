using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
  [Serializable]
  public class FoodInventory
  {
    private readonly Dictionary<int, FoodItem> _items = new ();

    [SerializeField] private SatiationMechanism _hungry;
    
    private static int _lastId;
    
    public void AddItem(FoodItem item)
    {
      item.Id = _lastId;
      _items[_lastId] = item;
      _lastId++;
    }

    public void EatItem(int itemId)
    {
      _hungry.Eat(_items[itemId]);
      _items.Remove(itemId);
    }
  }
}