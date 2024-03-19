using System.Collections.Generic;

namespace Core
{
  public interface IFishDeal
  {
    public (IEnumerable<Fish>, int) SellFish(IEnumerable<Fish> playersFishes);
  }
}