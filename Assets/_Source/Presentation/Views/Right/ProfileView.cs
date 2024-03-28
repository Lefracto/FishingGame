using Presentation.Panels;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Presentation.Views.Right
{
  public class ProfileView : MonoBehaviour
  {
    private PlayerStats _stats;

    // [Inject]
    public void Initialize(PlayerStats stats)
      => _stats = stats;


    [SerializeField] private AssetReference _profilePanel;
    [SerializeField] private Transform _canvasToSpawn;

    private ProfilePanel _panel;

    public async void ShowMenu()
    {
      var menu = _profilePanel.InstantiateAsync(_canvasToSpawn);
      await menu.Task;
      if (menu.Result.TryGetComponent(out _panel))
      {
      }
      else
        Debug.LogError("Error with SettingsPanel component.");
    }
  }
}