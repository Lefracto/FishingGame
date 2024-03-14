using System.Collections.Generic;
using System.Linq;

namespace Core
{
  public class TackleInventory
  {
    private readonly List<ITackle> _tackles = new();
    private readonly List<FishingSet> _fishingSets = new();


    public void AddTackle(TackleModel model)
    {
      ITackle tackle = TackleFactory.CreateTackle(model);
      TackleType tackleType = tackle.GetModel().GetTackleType();

      if (tackleType == TackleType.Rod)
      {
        _fishingSets.Add(new FishingSet((Rod)tackle));
      }
      else if (tackleType == TackleType.Bait &&
               _tackles.FirstOrDefault(tackle1 => tackle1.GetModel().Id == tackle.GetModel().Id) is Bait baitTackle)
      {
        baitTackle.Count += ((Bait)tackle).Count;
        return;
      }

      _tackles.Add(tackle);
    }

    public List<ITackle> GetOneTypeTackles(TackleType type)
      => _tackles.FindAll(tackle => tackle.GetModel().GetTackleType() == type);
  }
}