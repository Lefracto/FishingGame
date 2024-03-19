using UnityEngine;

namespace Core
{
  [CreateAssetMenu(fileName = "RodModel")]
  public class RodModel : TackleModel
  {
    public override TackleType GetTackleType()
      => TackleType.Rod;

    [field: SerializeField] public int MaxWeight { get; set; }
   
  }
}