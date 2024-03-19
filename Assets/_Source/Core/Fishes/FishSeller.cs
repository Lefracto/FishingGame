using System.Collections.Generic;
using Zenject;
using System.Linq;

namespace Core
{
  public class FishSeller
  {
    [Inject] private FishInventory _inventory;
    [Inject] private Wallet _wallet;

    // private List<IFishDeal> _deals;

    private void SellAllFish()
    {
      var fishesToSell = _inventory.GetFishes();
      SellFish(fishesToSell, 10 * fishesToSell.Count);
    }

    private void SellBigFish()
    {
      var fishesToSell = _inventory.GetFishes()
        .Where(fish => fish.Weight >= fish.Genus.MinScoringWeight).ToList(); 
      SellFish(fishesToSell, 1000 * fishesToSell.Count);
    }
    
    public void SellFishByDeal(int idOfDeal)
    {
      if (idOfDeal == -2)
      {
        SellBigFish();
        return;
      }

      if (idOfDeal == -1)
      {
        SellAllFish();
        return;
      }

      /*
      var fishToSellAndPrice = _deals[idOfDeal].SellFish(_inventory.GetFishes());
      _wallet.AddMoney(fishToSellAndPrice.Item2);

      foreach (Fish fish in fishToSellAndPrice.Item1)
        _inventory.TakeOutFish(fish.Id);
        */
    }

    private void SellFish(IEnumerable<Fish> fishes, int price)
    {
      foreach (Fish fish in fishes)
        _inventory.TakeOutFish(fish.Id);
      _wallet.AddMoney(price);
    }
  }
}