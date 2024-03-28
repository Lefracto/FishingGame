using UnityEngine;

namespace Core
{
  [CreateAssetMenu(menuName = "Tackle Models/Hook", order = 4)]

  public class HookModel : TackleModel
  {
    public override TackleType GetTackleType()
      => TackleType.Hook;
  }
}