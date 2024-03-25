using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;


namespace Core
{
  public class FoodShop : ISavable
  {
    private const string FOOD_INVENTORY_SAVE_PATH = "FoodInventory.json";
    [Space(15)] private Wallet _wallet;
    private FoodInventory _inventory;
    private List<FoodItem> _sellPositions;

    private CostsContainer _container;

    [Inject]
    public void Initialize(Wallet wallet, FoodInventory inventory, List<FoodItem> sellPositions,
      CostsContainer container)
    {
      _inventory = inventory;
      _wallet = wallet;
      _sellPositions = sellPositions;
      _container = container;
    }

    public bool TrySellFood(int goodId)
    {
      if (!_wallet.TryWriteOffMoney(_container.Costs[goodId]))
        return false;

      FoodItem position = _sellPositions.FirstOrDefault(x => x.Id == goodId);
      if (position != null)
        _inventory.AddItem(position, position.CountPortions);
      return true;
    }

    public (FoodItem, int) GetFood(int id)
    {
      return (_sellPositions.FirstOrDefault(x => x.Id == id), _container.Costs[id]);
    }

    public void SaveData()
    {
      var itemsToSave = _inventory.GetItems().Values.ToList();
      List<(int, int)> adoptedData = itemsToSave.Select(item => (item.Item1.Id, item.Item2)).ToList();
      SavesHelper.SerializeAndSave(adoptedData, FOOD_INVENTORY_SAVE_PATH);
    }

    public void LoadData()
    {
      var adoptedData = SavesHelper.LoadAndDeserialize<List<(int, int)>>(FOOD_INVENTORY_SAVE_PATH);
      foreach ((int, int) item in adoptedData)
        _inventory.AddItem(_sellPositions.FirstOrDefault(x => x.Id == item.Item1), item.Item2);
    }
  }
}