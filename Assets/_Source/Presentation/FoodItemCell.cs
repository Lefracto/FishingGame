using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FoodItemCell : MonoBehaviour
{
  [SerializeField] private Button _eatButton;
  [SerializeField] private TMP_Text _countText;
  [SerializeField] private TMP_Text _nameText;
  [SerializeField] private Image _foodIcon;

  public void SetCellConfig(FoodItem item, int id, int count, Action<int> eatItem)
  {
    _eatButton.onClick.AddListener(() => eatItem(id));
    _countText.text = count.ToString();
    _nameText.text = item.Name;
    _foodIcon.sprite = item.ItemIcon;
  }
}