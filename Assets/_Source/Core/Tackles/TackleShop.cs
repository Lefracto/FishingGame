using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Core
{
  public class TackleShop : MonoBehaviour
  {
    [SerializeField] private string _configPath;
    [SerializeField] private List<TackleModel> _models;
    [Inject] private CostsContainer _costsContainer;
    [SerializeField] private TackleInventory _inventory;

     private Wallet _wallet;
    private void Start()
    {
      
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