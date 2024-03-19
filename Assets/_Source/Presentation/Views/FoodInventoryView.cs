using Core;
using UnityEngine;
using Zenject;

public class FoodInventoryView : MonoBehaviour
{
  [Inject] private FoodInventory _inventory;
  [SerializeField] private RectTransform _inventoryPanel;
  [SerializeField] private RectTransform _inventoryContentPanel;

  [SerializeField] private GameObject _inventoryItemPrefab;
  
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