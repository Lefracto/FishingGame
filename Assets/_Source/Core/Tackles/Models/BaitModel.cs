using UnityEngine;

namespace Core
{
  [CreateAssetMenu(fileName = "Models\\Bait Model")]
  public class BaitModel : TackleModel
  {
    public override TackleType GetTackleType()
      => TackleType.Bait;
    
    public int CountInPack { get; set; }
  }
}