using System;
using System.Collections.Generic;
using Core.Locations;
using UnityEngine;

namespace Core
{
  [CreateAssetMenu(fileName = "FishBehaviour")]
  public class FishBehaviour : ScriptableObject
  {
    private FishGenus _genus;

    private int _minWeight;
    private int _maxWeight;

    public AnimationCurve _distributionOfWeight = new(new Keyframe(0, 0), new Keyframe(1, 0));

    public int[] DailyActivity = new int[24];
    
    [SerializeField]
    private List<BaitConfig> _fishPreferences = new ();

  }
}