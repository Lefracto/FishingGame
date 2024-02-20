using UnityEngine;

namespace Core
{
  public class BaitModel : TackleModel
  {
    public override TackleType GetTackleType()
      => TackleType.Bait;
    
    public int CountInPack { get; set; }
  }
}