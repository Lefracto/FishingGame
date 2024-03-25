using System;
using System.Collections.Generic;
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
  
  private GameObject _cellPrefab;
  
  private Func<TackleType, List<TackleModel>> _getTacklesOfType;

  
  public void AddCallDisplayTacklesOfTypeListener(Func<TackleType, List<TackleModel>> action)
    => _getTacklesOfType = action;

  public void CallDisplayTacklesOfType(int typeToShow)
  {
    ClearContent();
    var tackles =  _getTacklesOfType.Invoke((TackleType)typeToShow);
    foreach (var tackle in tackles)
    {
      GameObject tackleCell = Instantiate(_cellPrefab, _contentObject);
      if (tackleCell.TryGetComponent(out TackleShopCell cell))
      {
        
      }

      // tackleCell.SetCellConfig(tackle, () => DisplayTackle(tackle));
    }
    
  }

  private void ClearContent()
  {
    foreach (Transform child in _contentObject)
      Destroy(child.gameObject);
    
    
  }
  
}