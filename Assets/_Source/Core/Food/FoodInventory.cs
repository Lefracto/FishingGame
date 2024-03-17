using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
  [Serializable]
  public class FoodInventory : MonoBehaviour
  {
    private readonly Dictionary<int, FoodItem> _items = new();

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
      _hungry.IncreaseSatietyLevel(_items[itemId].SatietyPerPortion);
      _items[itemId].CountPortions--;

      if (_items[itemId].CountPortions == 0)
      {
        _items.Remove(itemId);
      }
    }
  }
}