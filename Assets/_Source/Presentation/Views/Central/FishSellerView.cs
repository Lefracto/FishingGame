using Core;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Presentation.Views
{
  public class FishSellerView : MonoBehaviour
  {
    [SerializeField] private AssetReference _inventoryPanel;
    [SerializeField] private Transform _canvasToSpawn;
    private FishSeller _seller;
    
    [Inject]
    public void Initialize(FishSeller seller)
      => _seller = seller;

    private void SellFish(int indexOfDeal)
      => _seller.SellFishByDeal(indexOfDeal);

    public async void ShowMenu()
    {
      var menu = _inventoryPanel.InstantiateAsync(_canvasToSpawn);
      await menu.Task;
      if (menu.Result.TryGetComponent(out FishSellerViewHelper helper))
        helper.InstallSellFishAction(SellFish);
      else
        Debug.LogError("Error with FishSellerViewHelper component.");
      
    }
  }
}