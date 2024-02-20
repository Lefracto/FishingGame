using UnityEngine;

namespace Core
{
  [CreateAssetMenu(fileName = "ReelModel")]
  public class ReelModel : TackleModel
  {
    public override TackleType GetTackleType()
      => TackleType.Reel;
    
    public int Power { get; set; }
  }
}