using Core;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Presentation.Views
{
  public class FoodShopView : MonoBehaviour
  {
    private FoodShop _shop;
    private int _selectedFoodId;
    private FoodShopPanel _helper;

    [SerializeField] private AssetReference _shopPanel;
    [SerializeField] private Transform _canvasToSpawn;

    [Inject]
    public void Initialize(FoodShop shop)
      => _shop = shop;

    public async void ShowMenu()
    {
      var menu = _shopPanel.InstantiateAsync(_canvasToSpawn);
      await menu.Task;

      if (menu.Result.TryGetComponent(out _helper))
      {
        _helper.AddButtonListener(BuyFood);
        _helper.AddFunctionality(_shop.GetFood);
      }
      else
        Debug.LogError("Error with FoodShopViewHelper component.");
    }

    // delete it
    public static int selectedFood;

    public void BuyFood()
      => _shop.TrySellFood(selectedFood);
  }
}