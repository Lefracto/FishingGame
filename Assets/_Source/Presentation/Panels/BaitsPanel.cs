using Presentation.Views.Cells;
using UnityEngine;
using System.Linq;
using Core;

namespace Presentation.Panels
{
  public class BaitsPanel : MonoBehaviour
  {
    [SerializeField] private GameObject _tackleCellPrefab;
    [SerializeField] private Transform _content;

    private TackleInventory _inventory;

    public void Initialize(TackleInventory inventory)
      => _inventory = inventory;

    public void DrawTackles()
    {
      var baits = _inventory.GetOneTypeTackles(TackleType.Bait);
      var convertedBaits = baits.Select(bait => bait as Bait).ToList();

      GameObject baitCell = Instantiate(_tackleCellPrefab, _content);

      if (baitCell.TryGetComponent(out BaitCell cell))
      {
        cell.SetBaitView();
      }
      else
      {
        Debug.LogError("No BaitCell");
      }
    }

    public void ChoseBaitForCurrentRod(int id)
    {
      
    }
  }
}