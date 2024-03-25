﻿using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Core
{
  public class TackleShop
  {
    private TackleInventory _inventory;
    private List<TackleModel> _models;
    private string _configPath;
    private Wallet _wallet;
    private CostsContainer _costsContainer;

    [Inject]
    public void Initialize(Wallet wallet, TackleInventory inventory, List<TackleModel> models,
      CostsContainer container)
    {
      _inventory = inventory;
      _wallet = wallet;
      _models = models;
      _costsContainer = container;
    }

    public List<(TackleModel, int)> GetModelsWithCostByType(TackleType type)
    {
      var models = _models.FindAll(model => model.GetTackleType() == type);
      List<(TackleModel, int)> modelsWithCost = new();
      models.ForEach(x => modelsWithCost.Add((x, _costsContainer.Costs[x.Id])));
      return modelsWithCost;
    }

    public bool TrySellTackle(int modelId)
    {
      if (!_wallet.TryWriteOffMoney(_costsContainer.Costs[modelId]))
        return false;

      _inventory.AddTackle(_models.Find(model => model.Id == modelId));
      return true;
    }
  }
}