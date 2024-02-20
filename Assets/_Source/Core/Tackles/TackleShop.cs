using System.Collections.Generic;
using UnityEngine;

namespace Core
{
  public class TackleShop : MonoBehaviour
  {
    [SerializeField] private string _configPath;
    [SerializeField] private List<TackleModel> _models;
    [SerializeField] private TackleInventory _inventory;
    [SerializeField] private Wallet _wallet;
    private CostsContainer _costsContainer;

    private void Start()
    {
      _costsContainer = new CostsContainer(_configPath);
    }
    
    public List<TackleModel> GetOneTackleTypeModels(TackleType type)
      => _models.FindAll(model => model.GetTackleType() == type);
    
    public bool TrySellTackle(int modelId)
    {
      if (!_wallet.TryWriteOffMoney(_costsContainer.Costs[modelId]))
        return false;

      _inventory.AddTackle(_models.Find(model => model.Id == modelId));
      return true;
    }
  }
}