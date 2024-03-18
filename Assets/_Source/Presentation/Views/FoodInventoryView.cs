using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;
using Zenject;

public class FoodInventoryView : MonoBehaviour
{
  [Inject] private FoodInventory _inventory;
  [SerializeField] private RectTransform _inventoryPanel;
  [SerializeField] private RectTransform _inventoryContentPanel;

  [SerializeField] private GameObject _inventoryItemPrefab;

  [Space(15)] [SerializeField] private FoodItem _item;

  void Start()
  {
    _inventory.AddItem(_item);
    _inventory.AddItem(_item);
    _inventory.AddItem(_item);
  }

  public void ShowInventory()
  {
    _inventoryPanel.gameObject.SetActive(true);
    _inventoryPanel.position = Vector3.zero;
    RedrawCells();
  }
  
  
  private void RedrawCells()
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

  public void CloseInventory()
  {
    _inventoryPanel.gameObject.SetActive(false);
    _inventoryPanel.position = new Vector3(1000, 1000, 1000);
  }
}