using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TackleShopCell : MonoBehaviour
{
  private string _postfix = " kg";
  [SerializeField] private TMP_Text _tackleLabel;
  [SerializeField] private TMP_Text _tackleShortInfo;
  [SerializeField] private Button _buyButton;
  
  public void SetPostfix(string postfix)
    => _postfix = postfix;

  public void SetCellConfig(string tackleName, string tackleInfo, Action onSelectTackle)
  {
    _tackleLabel.text = tackleName;
    _tackleShortInfo.text = tackleInfo + _postfix;
    _buyButton.onClick.AddListener(() => onSelectTackle());
  }
}