using UnityEngine;

namespace Core
{
  [CreateAssetMenu(fileName = "RodModel")]
  public class RodModel : ScriptableObject, ITackleModel
  {
    public TackleVisual Visual { get; set; }

    public int MaxWeight { get; set; }
    // some properties 
  }
}