using System.Collections.Generic;
using UnityEngine;

namespace Core
{
  public class FoodShop : MonoBehaviour
  {
    // TODO: rewrite
    //[SerializeField] private string _configFileName;
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private FoodInventory _inventory;
    [SerializeField] private List<FoodItem> _sellPositions;

    private Dictionary<int, int> _costsOfPositions;

    void Start()
    {
      // read
      ReadFoodCost();
    }

    private void ReadFoodCost()
    {
      _costsOfPositions = new Dictionary<int, int>();
      Debug.Log("Config has been read");
    }

    public bool TrySellFood(int goodId)
    {
      if (!_wallet.TryWriteOffMoney(_costsOfPositions[goodId]))
        return false;
      
      _inventory.AddItem(_sellPositions[goodId]);
      return true;
    }
  }
}