using System;
using Core;
using Presentation.Panels;
using Presentation.Views.Lower.Cells;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Presentation.Views.Lower
{
  public class GroundBaitView : MonoBehaviour
  {
    [SerializeField] private AssetReference _groundBaitPanel;
    [SerializeField] private Transform _canvasToSpawn;

    [SerializeField] private GameObject _baitCell;

    private TackleInventory _inventory;

    [Inject]
    public void Initialize(TackleInventory inventory)
      => _inventory = inventory;

    private GroundBaitPanel _panel;

    public async void ShowMenu()
    {
      var menu = _groundBaitPanel.InstantiateAsync(_canvasToSpawn);
      await menu.Task;
      if (menu.Result.TryGetComponent(out _panel))
      {
        RectTransform content = _panel.GetContent();

        foreach (ITackle groundBait in _inventory.GetOneTypeTackles(TackleType.GroundBait))
        {
          GroundBait bait = groundBait as GroundBait;
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
      GroundBait groundBait = _inventory.GetTackle(id) as GroundBait;
      groundBait.Count--;
      ShowMenu();
    }
  }
  
}