using UnityEngine;

namespace Core
{
  [CreateAssetMenu(menuName = "Tackle Models/Reel", order = 2)]

  public class ReelModel : TackleModel
  {
    public override TackleType GetTackleType()
      => TackleType.Reel;
    
    public int Power { get; set; }
  }
}