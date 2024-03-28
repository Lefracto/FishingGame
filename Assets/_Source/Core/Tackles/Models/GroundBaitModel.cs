using UnityEngine;

namespace Core
{
  [CreateAssetMenu(menuName = "Tackle Models/Ground Bait", order = 6)]
  public class GroundBaitModel :  TackleModel
  {
    public override TackleType GetTackleType()
      => TackleType.GroundBait;
    
    public int CountInPack { get; set; } 
  }
}