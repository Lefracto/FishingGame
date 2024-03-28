using Presentation.Panels;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Presentation.Views.Lower
{
  public class GroundBaitView : MonoBehaviour
  {
    [SerializeField] private AssetReference _groundBaitPanel;
    [SerializeField] private Transform _canvasToSpawn;

    [SerializeField] private GroundBaitPanel _panel;
  
    public async void ShowMenu()
    {
      var menu = _groundBaitPanel.InstantiateAsync(_canvasToSpawn);
      await menu.Task;
      if (menu.Result.TryGetComponent(out _panel))
      {
      
      }
      else
        Debug.LogError("Error with SettingsPanel component.");
    }
  }
}