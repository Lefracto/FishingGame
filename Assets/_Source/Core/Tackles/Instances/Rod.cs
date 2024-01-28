using UnityEngine;

namespace Core
{
  public class Rod
  {
    public RodModel Model { get; set; }
    
    [field: Range(0, 1)]
    public float WearLevel { get; private set; }
  }
}