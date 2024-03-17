using UnityEngine;

namespace Core
{
  [System.Serializable]
  public class TackleVisual
  {
    [field: SerializeField] public string Name { get; set; }
    [field: SerializeField] public Sprite Icon { get; set; }
    [field: SerializeField] public string Description { get; set; }
  }
}