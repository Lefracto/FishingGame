using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FoodShopPanel : SimplePanel
{
  [SerializeField] private Image _foodImage;
  [SerializeField] private TMP_Text _foodLabel;
  [SerializeField] private TMP_Text _foodPrice;
  [SerializeField] private Button _buyButton;
  private Func<int, (FoodItem, int)> _getFoodById;

  public void AddFunctionality(Func<int, (FoodItem, int)> getFoodById)
    => _getFoodById = getFoodById;
  
  public void AddButtonListener(UnityAction buyFood)
    => _buyButton.onClick.AddListener(buyFood);
  
  public void SelectFood(int selectedFoodId)
  {
    (FoodItem, int) foodWithCost = _getFoodById(selectedFoodId);
    _foodImage.sprite = foodWithCost.Item1.ItemIcon;
    _foodLabel.text = foodWithCost.Item1.Name;
    _foodPrice.text = foodWithCost.Item2.ToString();
  }
}