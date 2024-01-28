using UnityEngine;

namespace Core
{
  public class Reel
  {
    public ReelModel Model { get; set; }
    
    [field: Range(0, 1)]
    public float WearLevel { get; private set; }
  }
}