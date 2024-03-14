using System;
using System.Collections.Generic;

namespace Core
{
  public static class TackleFactory
  {
    private static int _lastTackleId;

    private static readonly Dictionary<TackleType, Func<TackleModel, ITackle>> factory_map = new()
    {
      { TackleType.Rod, model => new Rod(model, _lastTackleId++) },
      { TackleType.Reel, model => new Reel(model, _lastTackleId++) },
      { TackleType.Line, model => new Line(model, _lastTackleId++) },
      { TackleType.Hook, model => new Hook(model, _lastTackleId++) },
      { TackleType.Bait, model => new Bait(model, _lastTackleId++) }
    };

    public static ITackle CreateTackle(TackleModel model)
      => factory_map[model.GetTackleType()].Invoke(model);
  }
}