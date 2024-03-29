﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;
using Zenject;

namespace Core
{
  [Serializable]
  public class TackleInventory
  {
    public IReadOnlyList<ITackle> Tackles => _tackles;
    public IReadOnlyList<FishingSet> FishingSets => _fishingSets;
    
    private readonly List<ITackle> _tackles = new();
    private readonly List<FishingSet> _fishingSets = new();
    
    private void Initialise(IList<ITackle> startTackles, IList<FishingSet> startSets)
    {
      Debug.Log("Init");
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

    public List<ITackle> GetOneTypeTackles(TackleType type)
      => _tackles.FindAll(tackle => tackle.GetModel().GetTackleType() == type);
    public void AttachTackle(int rodId, int tackleId)
    {
      FishingSet fishingSet = _fishingSets.FirstOrDefault(set => set.Rod.Id == rodId);

      if (fishingSet == null)
        throw new System.InvalidOperationException($"FishingSet with Rod ID {rodId} not found.");
      
      ITackle tackle = _tackles.FirstOrDefault(t => t.GetModel().Id == tackleId);
      
      if (tackle == null)
        throw new System.InvalidOperationException($"Tackle with ID {tackleId} not found.");
      
      DetachTackle(fishingSet, tackle.GetModel().GetTackleType());
      fishingSet[tackle.GetModel().GetTackleType()] = tackle;
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
      _tackles.Add(fishingSet[tackleType]);
      fishingSet[tackleType] = null;
    }
  }
}