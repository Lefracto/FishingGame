using System.Collections.Generic;
using System.Linq;
using Core.Locations;
using UnityEngine;

public class TravelsController : MonoBehaviour
{
  [SerializeField] private List<FishingLocation> _locations;
  [SerializeField] private FishingLocation _standardLocation;

  [SerializeField] private SpotManager _spotManager;

  public void GoToLocation(int id)
    => _spotManager.SetCurrentLocation(_locations.FirstOrDefault(x => x.GetId == id));
}