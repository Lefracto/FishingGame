using Core;
using TMPro;
using UnityEngine;
using Zenject;

namespace Presentation.Views
{
  public class FishSellerView : MonoBehaviour
  {
    [Inject] private FishSeller _seller;
    //[SerializeField] private TMP_Text _tableText;
    
    public void SellFish(int indexOfDeal)
    {
      _seller.SellFishByDeal(indexOfDeal);
    }
    
  }
}