using System;
using Core;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TackleShopCell : MonoBehaviour
{
  private string _postfix = " руб.";
  [SerializeField] private TMP_Text _tackleLabel;
  [SerializeField] private TMP_Text _tackleShortInfo;
  [SerializeField] private Button _buyButton;
  
  public void SetPostfix(string postfix)
    => _postfix = postfix;

  public void SetCellConfig(string tackleName, string cost, Action<int> onSelectTackle, int id)
  {
    _tackleLabel.text = tackleName;
    _tackleShortInfo.text = cost + _postfix;
    _buyButton.onClick.AddListener((() => onSelectTackle(id)));
  }
}