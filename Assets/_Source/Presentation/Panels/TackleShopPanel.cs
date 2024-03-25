using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TackleShopPanel : InventoryPanel
{
  [SerializeField] private Image _tackleImage;
  [SerializeField] private TMP_Text _tackleLabel;
  [SerializeField] private TMP_Text _tackleDescription;
  [SerializeField] private TMP_Text _tackleCost;

  [SerializeField] private GameObject _cellPrefab;

  private Func<TackleType, List<(TackleModel, int)>> _getTacklesOfType;
  private Action<int> _onBuyButton;
  private List<(TackleModel, int)> _modelsWithCosts;

  private int _selectedTackleId;
  
  public void AddOnBuyHandler(Action<int> handler)
    => _onBuyButton += handler;
  
  public void AddCallDisplayTacklesOfTypeListener(Func<TackleType, List<(TackleModel, int)>> action)
    => _getTacklesOfType = action;

  public void CallDisplayTacklesOfType(int typeToShow)
  {
    ClearContent();
    _modelsWithCosts = _getTacklesOfType.Invoke((TackleType)typeToShow);
    foreach ((TackleModel, int) tackle in _modelsWithCosts)
    {
      GameObject tackleCell = Instantiate(_cellPrefab, _contentObject);
      if (tackleCell.TryGetComponent(out TackleShopCell cell))
      {
        cell.SetCellConfig(tackle.Item1.name, tackle.Item2.ToString(), SelectTackle, tackle.Item1.Id);
      }
      else
      {
        Debug.LogError("It doesn't work!");
      }
    }
  }

  private void SelectTackle(int id)
  {
    _selectedTackleId = id;
    (TackleModel, int) model = _modelsWithCosts.FirstOrDefault(model => model.Item1.Id == id);
    _tackleImage.sprite = model.Item1.Visual.Icon;
    _tackleLabel.text = model.Item1.name;
    _tackleDescription.text = model.Item1.Visual.Description;
    _tackleCost.text = model.Item2.ToString();
  }

  private void ClearContent()
  {
    foreach (Transform child in _contentObject)
      Destroy(child.gameObject);

    _tackleImage.sprite = null;
    _tackleLabel.text = "";
    _tackleDescription.text = "";
    _tackleCost.text = "";
  }

  public void BuySelectedTackle()
    => _onBuyButton.Invoke(_selectedTackleId);
}