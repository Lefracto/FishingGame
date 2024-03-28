using Presentation.Panels;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

public class SettingsView : MonoBehaviour
{
  [SerializeField] private AssetReference _settingsPanel;
  [SerializeField] private Transform _canvasToSpawn;

  [SerializeField] private SettingsPanel _panel;


  private SavesLoader _loader;

//  [Inject]
  public void Initialize(SavesLoader loader)
    => _loader = loader;

  public async void ShowMenu()
  {
    var menu = _settingsPanel.InstantiateAsync(_canvasToSpawn);
    await menu.Task;
    if (menu.Result.TryGetComponent(out _panel))
    {
      _panel.SetLoader(_loader);
    }
    else
      Debug.LogError("Error with SettingsPanel component.");
  }
}