using UnityEngine;

namespace Core
{
  public class RodModel : ScriptableObject
  {
    public TackleVisual Visual { get; set; }

    public int MaxLoad { get; set; }
    // some properties 
  }
}