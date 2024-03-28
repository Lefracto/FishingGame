using Core;
using Presentation.Panels;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

public class TackleInventoryView : MonoBehaviour
{
  private TackleInventory _inventory;

  [SerializeField] private GameObject _baitsCellPrefab;

  [SerializeField] private GameObject _cellPrefab;
  [SerializeField] private Transform _canvasToSpawn;
  [SerializeField] private AssetReference _inventoryPanel;

  private TackleInventoryPanel _panel;

  [Inject]
  public void Initialize(TackleInventory inventory)
    => _inventory = inventory;
  
  public async void ShowFullMenu()
  {
    var menu = _inventoryPanel.InstantiateAsync(_canvasToSpawn);
    await menu.Task;

    if (menu.Result.TryGetComponent(out _panel))
    {
      _panel.Initialize(_inventory, _cellPrefab);
    }
    else
      Debug.LogError("Error with TackleInventoryPanel component.");
  }
}