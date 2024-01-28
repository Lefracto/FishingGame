using UnityEngine;

namespace Core
{
  public class BaitModel : ScriptableObject
  {
    public TackleVisual Visual { get; set; }
    public int CountInPack { get; set; }
  }
}