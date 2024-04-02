using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Presentation.Views.Lower.Cells
{
  public class GBaitCell : MonoBehaviour
  { 
    [SerializeField] private Button _useButton;
    [SerializeField] private TMP_Text _countText;
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private Image _foodIcon;

    public void SetCellConfig(Sprite icon, string gBaitName, int id, int count, Action<int> useGBait)
    {
      _useButton.onClick.AddListener(() => useGBait(id));
      _countText.text = count.ToString();
      _nameText.text = gBaitName;
      _foodIcon.sprite = icon;
    }
  }
}