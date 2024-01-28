using UnityEngine;

namespace Core
{
  public class Hook
  {
    public HookModel Model { get; set; }
    
    [field: Range(0, 1)]
    public float WearLevel { get; private set; }
  }
}