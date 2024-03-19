using System;
using Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class FishInventoryView : MonoBehaviour
{
  [Inject] private FishInventory _inventory;
  [SerializeField] private GameObject _fishCellPrefab;
  [SerializeField] private Transform _content;

  [Space(15)] [SerializeField] private Image _icon;
  [SerializeField] private TMP_Text _fishName;
  [SerializeField] private TMP_Text _fishWeight;
  [SerializeField] private TMP_Text _fishDescription;

  [Space(30)] public FishGenus Genus;
  [Space(30)] public FishGenus Genus2;

  private void Start()
  {
    _inventory.TakeInFish(new Fish(Genus, 100, 1));
    _inventory.TakeInFish(new Fish(Genus2, 2100, 2));

  }

  private void ResetSelect()
  {
    _icon.sprite = null;
    _fishName.text = " ";
    _fishWeight.text = " ";
    _fishDescription.text = " ";
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
    _icon.sprite = selectedFish.Genus.FishImage;
    _fishName.text = selectedFish.Genus.Name;
    _fishWeight.text = selectedFish.Weight.ToString();
    _fishDescription.text = selectedFish.Genus.Description;
  }
}