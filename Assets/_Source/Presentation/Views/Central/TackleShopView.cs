using Core;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Presentation.Views
{
  public class TackleShopView : MonoBehaviour
  {
    private TackleShop _shop;

    [SerializeField] private AssetReference _shopPanel;
    [SerializeField] private Transform _canvasToSpawn;
    
    private TackleShopPanel _panel;
    private int _currentTackleId;
    
    [Inject]
    public void Initialize(TackleShop shop)
      => _shop = shop;
    
    public async void ShowMenu()
    {
      var menu = _shopPanel.InstantiateAsync(_canvasToSpawn);
      await menu.Task;
      if (menu.Result.TryGetComponent(out _panel))
      {
        _panel = menu.Result.GetComponent<TackleShopPanel>();
        _panel.AddCallDisplayTacklesOfTypeListener(_shop.GetModelsWithCostByType);
        _panel.AddOnBuyHandler(BuyTackle);
      }
      else
        Debug.LogError("Error with InventoryViewHelper component.");
    }

    private void BuyTackle(int id)
      => _shop.TrySellTackle(id);
  }
}