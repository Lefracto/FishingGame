using System;

public class FishSellerViewHelper : ViewHelper
{
  private Action<int> _sellFish;

  public void InstallSellFishAction(Action<int> sellFish)
   => _sellFish = sellFish;
  
  public void SellFish(int id)
    => _sellFish?.Invoke(id);
}