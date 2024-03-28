using UnityEngine;

namespace Core
{
  [CreateAssetMenu(menuName = "Tackle Models/Line", order = 3)]

  public class LineModel : TackleModel
  {
    public override TackleType GetTackleType()
      => TackleType.Line;
    
    public int MaxLoad { get; set; }
  }
}