using System.Threading;
using Core.Locations;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;
using Zenject;

public class SpotManager : MonoBehaviour
{
  private FishingSpot _currentSpot;
  [SerializeField]
  private FishingLocation _location;
  
  [SerializeField] private GameObject _baseCanvas;
  [SerializeField] private GameObject _spotCanvas;
  
  [SerializeField] private AssetReference _spotsPanel;
  [SerializeField] private Transform _canvasToSpawn;
  [SerializeField] private Image _spotImage;


  [Inject]
  public void Initialize(FishingLocation startLocation)
  {
    _location = startLocation;
  }
  
  private SpotsPanel _panel;

  public void SetCurrentLocation(FishingLocation newLocation)
  {
    _location = newLocation;
  }
  
  public void BackToBase()
  {
    _baseCanvas.SetActive(true);
    _spotCanvas.SetActive(false);
  }

  public async void ShowSpotsPanel()
  {
    var menu = _spotsPanel.InstantiateAsync(_canvasToSpawn);
    await menu.Task;
    if (menu.Result.TryGetComponent(out _panel))
    {
      _panel.AddLoadSpotHandler(LoadSpot);
    }
    else
      Debug.LogError("Error with InventoryViewHelper component.");
  }

  private void LoadSpot(int id)
  {
    Destroy(_panel.gameObject);
    Thread.Sleep(500);
    _baseCanvas.SetActive(false);
    _spotCanvas.SetActive(true);
    _currentSpot = _location.Spots[id];
    _spotImage.sprite = _currentSpot.SpotBackGround;
  }
}