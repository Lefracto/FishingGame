using UnityEngine;

namespace Core
{
  public class LineModel : TackleModel
  {
    public override TackleType GetTackleType()
      => TackleType.Line;
    
    public int MaxLoad { get; set; }
  }
}