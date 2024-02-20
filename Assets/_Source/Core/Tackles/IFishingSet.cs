using System;
using UnityEngine;

namespace Core
{
  public class FishingSet
  {
    public FishingSet(Rod rod)
    {
      Rod = rod;
    }
    
      public Rod Rod { get; private set; }
      [field: SerializeField] public Reel Reel { get; set; }
      [field: SerializeField] public Line Line { get; set; }
      [field: SerializeField] public Hook Hook { get; set; }
      [field: SerializeField] public Bait Bait { get; set; }

  }
}