using Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Presentation.Views
{
  public class FoodShopView : MonoBehaviour
  {
    [Inject] private FoodShop _shop;

    [SerializeField] private TMP_Text _foodLabel;
    [SerializeField] private TMP_Text _costText;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _buyButton;

    private int _selectedFoodId;
    
    public void BuyFood()
    {
      _shop.TrySellFood(_selectedFoodId);
    }

    public void SelectFood(int id)
    {
      _selectedFoodId = id;
      (FoodItem, int) foodWithCost = _shop.GetFood(id);

      _icon.sprite = foodWithCost.Item1.ItemIcon;
      _foodLabel.text = foodWithCost.Item1.Name;
      _costText.text = foodWithCost.Item2.ToString();
    }
  }
}