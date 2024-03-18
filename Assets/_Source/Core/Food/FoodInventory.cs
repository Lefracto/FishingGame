using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Core
{
  [Serializable]
  public class FoodInventory
  {
    private  Dictionary<int, (FoodItem, int)> _items = new();

    [Inject] [SerializeField] private SatiationMechanism _hungry;

    private static int _lastId;

    public Dictionary<int, (FoodItem, int)> GetItems()
      => _items;

    public void AddItem(FoodItem item)
    {
      item.Id = _lastId;
      _items[_lastId] = (item, item.CountPortions);
      _lastId++;
    }

    public void EatItem(int itemId)
    {
      (FoodItem, int) itemTuple = _items[itemId];
      itemTuple.Item2--;

      if (itemTuple.Item2 == 0)
        _items.Remove(itemId);
      else
        _items[itemId] = itemTuple;

      _hungry.IncreaseSatietyLevel(itemTuple.Item2);
    }
  }
}