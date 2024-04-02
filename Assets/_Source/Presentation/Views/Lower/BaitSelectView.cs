using Core;
using Presentation.Panels;
using Presentation.Views.Lower.Cells;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;
using Zenject;

namespace Presentation.Views.Lower
{
  public class BaitSelectView : MonoBehaviour
  {
    [SerializeField] private AssetReference _groundBaitPanel;
    [SerializeField] private Transform _canvasToSpawn;

    [SerializeField] private GameObject _baitCell;
    [SerializeField] private Image _baitImage;
    
    private TackleInventory _inventory;

    [Inject]
    public void Initialize(TackleInventory inventory)
      => _inventory = inventory;

    private BaitsPanel _panel;

    public static bool IsBase = true;
    public static int CurrentBaitId = -1;
    
    
    public async void ShowMenu()
    {
      if (IsBase)
        return;
      
      var menu = _groundBaitPanel.InstantiateAsync(_canvasToSpawn);
      await menu.Task;
      if (menu.Result.TryGetComponent(out _panel))
      {
        RectTransform content = _panel.GetContent();

        foreach (ITackle groundBait in _inventory.GetOneTypeTackles(TackleType.Bait))
        {
          Bait bait = groundBait as Bait;
          GameObject cell = Instantiate(_baitCell, content);

          if (cell.TryGetComponent(out GBaitCell _baitCellConfig))
          {
            _baitCellConfig.SetCellConfig(bait.GetModel().Visual.Icon, bait.GetModel().Visual.Name, bait.Id, bait.Count,
              UseGroundBait);
            
            
          }
          
          
        }
      }
      else
        Debug.LogError("Error with SettingsPanel component.");
    }

    private void UseGroundBait(int id)
    {
      Debug.Log($"You have used bait with id: {id}");
      Bait bait = _inventory.GetTackle(id) as Bait;
      CurrentBaitId = id;
      _baitImage.sprite = bait.GetModel().Visual.Icon;
    }
  }
}