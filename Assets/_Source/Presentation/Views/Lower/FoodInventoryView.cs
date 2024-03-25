using Core;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

public class FoodInventoryView : MonoBehaviour
{
  private FoodInventory _inventory;
  [SerializeField] private AssetReference _inventoryPanel;
  [SerializeField] private GameObject _inventoryItemPrefab;
  [SerializeField] private Transform _canvasToSpawn;
  
  private RectTransform _inventoryContentPanel;

  [Inject]
  public void Initialize(FoodInventory inventory)
  {
    _inventory = inventory;
  }

  public async void ShowMenu()
  {
    var menu = _inventoryPanel.InstantiateAsync(_canvasToSpawn);
    await menu.Task;
    InventoryViewHelper deleter = menu.Result.GetComponent<InventoryViewHelper>();
    _inventoryContentPanel = deleter.GetContent();
    RedrawCells();
  }
  
  public void RedrawCells()
  {
    foreach (Transform child in _inventoryContentPanel.transform)
      Destroy(child.gameObject);
    
    var foodItems = _inventory.GetItems();

    foreach (var item in foodItems)
    {
      GameObject foodCell = Instantiate(_inventoryItemPrefab, _inventoryContentPanel);
      FoodItemCell cell = foodCell.GetComponent<FoodItemCell>();
      cell.SetCellConfig(item.Value.Item1, item.Key, item.Value.Item2, EatItem);
    }
  }

  public void EatItem(int itemId)
  {
    _inventory.EatItem(itemId);
    RedrawCells();
  }
}