using UnityEngine;

namespace Core
{
  [CreateAssetMenu(menuName = "Tackle Models/Rod", order = 1)]
  public class RodModel : TackleModel
  {
    public override TackleType GetTackleType()
      => TackleType.Rod;

    [field: SerializeField] public int MaxWeight { get; set; }
  }
}