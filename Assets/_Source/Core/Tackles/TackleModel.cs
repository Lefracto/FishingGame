using UnityEngine;

namespace Core
{
  public abstract class TackleModel : ScriptableObject
  {
    [field: SerializeField]
    public int Id { get; set; }
    public abstract TackleType GetTackleType();
    
    [field: SerializeField]
    public TackleVisual Visual { get; set; }
  }
}