using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Presentation.Views
{
  public class RodsVisual
  {
    [SerializeField] private AssetReference _rodPrefab;
    
    public void ShowRod()
    {
      _rodPrefab.InstantiateAsync();
    }
  }
}