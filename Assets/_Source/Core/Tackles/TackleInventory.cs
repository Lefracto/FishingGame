using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace Core
{
  [Serializable]
  public class TackleInventory
  {
    public IReadOnlyList<ITackle> Tackles => _tackles;
    public IReadOnlyList<FishingSet> FishingSets => _fishingSets;

    private readonly List<ITackle> _tackles = new();
    private readonly List<FishingSet> _fishingSets = new();

    public List<FishingSet> GetAllSets()
      => _fishingSets;
    
    private List<int> _installedTacklesId = new List<int>();

    public List<int> InstalledTacklesId
    {
      get
      {
        //if (_installedTacklesId == null)
         // InstalledTacklesId = new List<int>();

        return _installedTacklesId;
      }
      set => _installedTacklesId = value;
    }

    public FishingSet GetSet(int rodId)
      => _fishingSets.FirstOrDefault(set => set.Rod.Id == rodId);

    private void Initialise(IList<ITackle> startTackles, IList<FishingSet> startSets)
    {
      _tackles.AddRange(startTackles);
      _fishingSets.AddRange(startSets);
    }


    public void AddTackle(TackleModel model)
    {
      ITackle tackle = TackleFactory.CreateTackle(model);
      TackleType tackleType = tackle.GetModel().GetTackleType();

      if (tackleType == TackleType.Rod)
        _fishingSets.Add(new FishingSet((Rod)tackle));
      else if (tackleType == TackleType.Bait &&
               _tackles.FirstOrDefault(tackle1 => tackle1.GetModel().Id == tackle.GetModel().Id) is Bait baitTackle)
      {
        baitTackle.Count += ((Bait)tackle).Count;
        return;
      }

      _tackles.Add(tackle);
    }

    public ITackle GetTackle(int id)
      => _tackles.FirstOrDefault(tackle => tackle.Id == id);

    public List<ITackle> GetOneTypeTackles(TackleType type)
      => _tackles.FindAll(tackle => tackle.GetModel().GetTackleType() == type);

    public void AttachTackle(int rodId, int tackleId)
    {
      FishingSet fishingSet = _fishingSets.FirstOrDefault(set => set.Rod.Id == rodId);

      if (fishingSet == null)
        throw new System.InvalidOperationException($"FishingSet with Rod ID {rodId} not found.");

      ITackle tackle = _tackles.FirstOrDefault(t => t.Id == tackleId);

      if (tackle == null)
        throw new System.InvalidOperationException($"Tackle with ID {tackleId} not found.");
      
      DetachTackle(fishingSet, tackle.GetModel().GetTackleType());

      fishingSet[tackle.GetModel().GetTackleType()] = tackle;
      InstalledTacklesId.Add(tackle.Id);
    }

    public void DetachTackle(int rodId, TackleType tackleType)
    {
      FishingSet fishingSet = _fishingSets.FirstOrDefault(set => set.Rod.Id == rodId);
      if (fishingSet == null)
        return;
      DetachTackle(fishingSet, tackleType);
    }

    private void DetachTackle(FishingSet fishingSet, TackleType tackleType)
    {
      Debug.Log(tackleType + " was detached");
      if (fishingSet[tackleType] != null)
        InstalledTacklesId.Remove(fishingSet[tackleType].Id);
    }
  }
}