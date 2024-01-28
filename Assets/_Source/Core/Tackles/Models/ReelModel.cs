using UnityEngine;

namespace Core
{
  public class ReelModel : ScriptableObject
  {
    public TackleVisual Visual { get; set; }
    public int Power { get; set; }
  }
}