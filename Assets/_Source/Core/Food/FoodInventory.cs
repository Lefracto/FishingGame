using System;
using System.Collections.Generic;

namespace Core
{
  [Serializable]
  public class FoodInventory
  {
    private Dictionary<int, (FoodItem, int)> _items = new();

    private SatiationMechanism _hungry;
    private static int _lastId;

    public Dictionary<int, (FoodItem, int)> GetItems()
      => _items;

    public FoodInventory(IEnumerable<FoodItem> items, SatiationMechanism hungry)
    {
      _hungry = hungry;
      if (items == null)
        return;

      foreach (FoodItem foodItem in items)
        AddItem(foodItem, foodItem.CountPortions);
    }

    public void AddItem(FoodItem item, int countPortions)
    {
      _items[_lastId] = (item, countPortions);
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

      _hungry.IncreaseSatietyLevel(itemTuple.Item1.SatietyPerPortion);
    }
  }
}