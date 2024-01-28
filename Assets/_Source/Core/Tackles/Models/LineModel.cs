using UnityEngine;

namespace Core
{
  public class LineModel : ScriptableObject
  {
    public TackleVisual Visual { get; set; }
    public int MaxLoad { get; set; }
  }
}