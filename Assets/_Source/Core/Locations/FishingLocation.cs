using System.Collections.Generic;
using UnityEngine;

namespace Core.Locations
{
  [CreateAssetMenu(fileName = "Fishing Location")]

  public class FishingLocation : ScriptableObject
  {
    [SerializeField]
    private int _id;
    public int GetId => _id;
    
    public Sprite SpotBackGround;
    public List<FishingSpot> Spots;
  }
}