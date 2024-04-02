using UnityEngine;

namespace Core
{
  [CreateAssetMenu(menuName = "Tackle Models/Bait", order = 5)]
  public class BaitModel : TackleModel
  {
    public override TackleType GetTackleType()
      => TackleType.Bait;

    public int CountInPack;
  }
}