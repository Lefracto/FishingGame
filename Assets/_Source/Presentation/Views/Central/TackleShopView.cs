using Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Presentation.Views
{
  public class TackleShopView : MonoBehaviour
  {
    private TackleShop _shop;

    [SerializeField] private Image _tackleImage;
    [SerializeField] private TMP_Text _tackleLabel;
    [SerializeField] private TMP_Text _tackleDescription;
    [SerializeField] private TMP_Text _tackleCost;

    [SerializeField] private Button _buyButton;

    public void ShowTackleCategory(TackleType typeToShow)
    {
      
    }

    public void SelectTackle(int id)
    {
      
    }
  }
}