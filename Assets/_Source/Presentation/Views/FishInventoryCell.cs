using System;
using Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FishInventoryCell : MonoBehaviour
{
  [SerializeField] private TMP_Text _fishNameText;
  [SerializeField] private TMP_Text _weightText;
  
  [SerializeField] private Button _button;
  
  public void SetCellConfig(Fish fish, Action<int> onClickHandler)
  {
    _fishNameText.text = fish.Genus.Name;
    _weightText.text = fish.Weight.ToString();
    _button.onClick.AddListener(() => onClickHandler(fish.Id));
  }
}