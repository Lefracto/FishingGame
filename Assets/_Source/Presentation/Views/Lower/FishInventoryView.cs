using Core;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

public class FishInventoryView : MonoBehaviour
{
  private FishInventory _inventory;
  [SerializeField] private GameObject _fishCellPrefab;
  [SerializeField] private AssetReference _inventoryPanel;
  [SerializeField] private Transform _canvasToSpawn;

  private Transform _content;
  private FishInventoryViewHelper _helper;

  [Space(30)] public FishGenus Genus;
  [Space(30)] public FishGenus Genus2;

  [Inject]
  public void Initialize(FishInventory inventory)
  {
    // TODO remove it. Just for test
    inventory.TakeInFish(new Fish(Genus, 100, 1));
    inventory.TakeInFish(new Fish(Genus2, 2100, 2));

    _inventory = inventory;
  }

  public async void ShowMenu()
  {
    var handle = _inventoryPanel.LoadAssetAsync<GameObject>();
    await handle.Task;
    GameObject gameObjectPrefab = handle.Result;
    GameObject menu = Instantiate(gameObjectPrefab, _canvasToSpawn);
    InventoryViewHelper deleter = menu.GetComponent<InventoryViewHelper>();
    _content = deleter.GetContent();
    Addressables.Release(handle);

    _helper = menu.GetComponent<FishInventoryViewHelper>();
    RedrawCells();
  }


  private void ResetSelect()
  {
    _helper.FishImage.sprite = null;
    _helper.FishLabel.text = " ";
    _helper.FishDescription.text = " ";
    _helper.FishWeight.text = " ";
  }

  public void RedrawCells()
  {
    ResetSelect();

    foreach (Transform child in _content)
      Destroy(child.gameObject);

    var fishes = _inventory.GetFishes();
    foreach (Fish fish in fishes)
    {
      GameObject fishCell = Instantiate(_fishCellPrefab, _content);
      FishInventoryCell cell = fishCell.GetComponent<FishInventoryCell>();
      cell.SetCellConfig(fish, SelectFish);
    }
  }

  private void SelectFish(int id)
  {
    Fish selectedFish = _inventory.GetFish(id);

    _helper.FishImage.sprite = selectedFish.Genus.FishImage;
    _helper.FishLabel.text = selectedFish.Genus.Name;
    _helper.FishWeight.text = selectedFish.Weight.ToString();
    _helper.FishDescription.text = selectedFish.Genus.Description;
  }
}