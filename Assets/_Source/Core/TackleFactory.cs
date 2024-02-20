using System;
using System.Collections.Generic;

namespace Core
{
  public static class TackleFactory
  {
    private static readonly Dictionary<TackleType, Func<TackleModel, ITackle>> factory_map = new()
    {
      { TackleType.Rod, model => new Rod(model) },
      //  { TackleType.Reel, model => new Reel(model) }
      //  { TackleType.Line, model => new Line(model) }
      //  { TackleType.Hook, model => new Hook(model) }
      //  { TackleType.Bait, model => new Bait(model) }
      //  { TackleType.Jig, model => new Jig(model) }
    };

    public static ITackle CreateTackle(TackleModel model)
      => factory_map[model.GetTackleType()].Invoke(model);
  }
}