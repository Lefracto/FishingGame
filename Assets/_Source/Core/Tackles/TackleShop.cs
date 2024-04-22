using System;
using System.Collections.Generic;
using System.Linq;
using Zenject;


namespace Core
{
  public class TackleShop : ISavable
  {
    private const string CONFIG_FILE_NAME = "tackles.json";


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


    public void SaveData()
    {
      var modelsId = _inventory.Tackles.Select(x => x.GetModel().Id).ToList();
      SavesHelper.SerializeAndSave(modelsId, CONFIG_FILE_NAME);
    }

    public void LoadData()
    {
      try
      {
        var modelsId = SavesHelper.LoadAndDeserialize<List<int>>(CONFIG_FILE_NAME);
        modelsId.ForEach(x => _inventory.AddTackle(_models.Find(model => model.Id == x)));
      }
      catch (Exception)
      {
        SaveData();
      }
    }
  }
}