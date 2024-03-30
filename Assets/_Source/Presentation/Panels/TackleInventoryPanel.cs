using System.Collections.Generic;
using Presentation.Views.Lower.Cells;
using UnityEngine.UI;
using System.Linq;
using UnityEngine;
using TMPro;
using Core;

namespace Presentation.Panels
{
  public class TackleInventoryPanel : SimplePanel
  {
    [SerializeField] private List<TMP_Text> _labels;
    [SerializeField] private List<Image> _images;
    [SerializeField] private List<Transform> _contents;

    private GameObject _cell;
    private TackleInventory _inventory;
    
    public RodOperator RodOperator { get; set; }
    
    public void Initialize(TackleInventory inventory, GameObject cell)
    {
      _inventory = inventory;
      _cell = cell;
      
      DrawInventory();
    }

    private int _selectedRod = -1;

    private void SelectRod(int id)
    {
      FishingSet set = _inventory.GetSet(id);

      if (set == null)
        Debug.LogError("Set is null");

      for (int i = 0; i < 4; i++)
      {
        var t = set[(TackleType)i];
        if (t != null)
          _labels[i].text = set[(TackleType)i].GetModel().Visual.Name;
        else
          _labels[i].text = " ";

        var t2 = set[(TackleType)i];

        if (t2 != null)
          _images[i].sprite = set[(TackleType)i].GetModel().Visual.Icon;
        else
        {
          _images[i].sprite = null;
        }
      }

      _selectedRod = id;
    }

    private void InstallTackle(int id)
    {
      if (_selectedRod == -1)
        return;

      FishingSet set = _inventory.GetSet(_selectedRod);
      _inventory.AttachTackle(_selectedRod, id);

      ClearContents();
      DrawInventory();
      SelectRod(_selectedRod);
    }

    private void DrawInventory()
    {
      var rodsList = _inventory.GetOneTypeTackles(TackleType.Rod).Select(rod => rod as Rod).ToList();
      var reelsList = _inventory.GetOneTypeTackles(TackleType.Reel).Select(rod => rod as Reel).ToList();
      var linesList = _inventory.GetOneTypeTackles(TackleType.Line).Select(rod => rod as Line).ToList();
      var hooksList = _inventory.GetOneTypeTackles(TackleType.Hook).Select(rod => rod as Hook).ToList();


      foreach (Rod rod in rodsList)
      {
        GameObject cell = Instantiate(_cell, _contents[0]);
        cell.GetComponent<TackleCell>()
          .Initialize(rod.GetModel().Visual.Name, (rod.GetModel() as RodModel)?.MaxWeight + " кг.", SelectRod,
            rod.Id);
      }

      foreach (Reel reel in reelsList)
      {
        if (_inventory.InstalledTacklesId.Contains(reel.Id))
          continue;

        GameObject cell = Instantiate(_cell, _contents[1]);
        cell.GetComponent<TackleCell>()
          .Initialize(reel.GetModel().Visual.Name, reel.WearLevel * 100 + "%", InstallTackle, reel.Id);
      }

      foreach (Line line in linesList)
      {
        if (_inventory.InstalledTacklesId.Contains(line.Id))
          continue;

        GameObject cell = Instantiate(_cell, _contents[2]);
        cell.GetComponent<TackleCell>()
          .Initialize(line.GetModel().Visual.Name, line.WearLevel * 100 + "%", InstallTackle, line.Id);
      }

      foreach (Hook hook in hooksList)
      {
        if (_inventory.InstalledTacklesId.Contains(hook.Id))
          continue;

        GameObject cell = Instantiate(_cell, _contents[3]);
        cell.GetComponent<TackleCell>()
          .Initialize(hook.GetModel().Visual.Name, " ", InstallTackle, hook.Id);
      }
    }

    public void Detach(int type)
    {
      FishingSet set = _inventory.GetSet(_selectedRod);
      if (_selectedRod == -1 || set[(TackleType)type] == null)
        return;

      _inventory.InstalledTacklesId.Remove(set[(TackleType)type].Id);
      set[(TackleType)type] = null;

      ClearContents();
      DrawInventory();
      SelectRod(_selectedRod);
    }

    public void ClearContents()
    {
      foreach (Transform child in _contents.SelectMany(content => content.Cast<Transform>()))
        Destroy(child.gameObject);
    }

    public void RetrieveRod()
    {
      if (RodOperator.RetrieveRod(_inventory.GetSet(_selectedRod)))
        DeleteMyself();
    }
  }
}