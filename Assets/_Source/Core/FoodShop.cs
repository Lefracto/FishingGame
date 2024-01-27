﻿using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using System.IO;

namespace Core
{
  public class FoodShop : MonoBehaviour
  {
    [SerializeField] private string _configFileName;

    [Space(15)] [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private FoodInventory _inventory;
    [SerializeField] private List<FoodItem> _sellPositions;

    private Dictionary<int, int> _costsOfPositions;

    void Start()
    {
      ReadFoodCost();
    }

    private void ReadFoodCost()
    {
      _costsOfPositions = new Dictionary<int, int>();
      string serializedObject = File.ReadAllText(_configFileName);
      _costsOfPositions = JsonConvert.DeserializeObject<Dictionary<int, int>>(serializedObject);
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