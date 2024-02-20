﻿using System.Collections.Generic;

namespace Core
{
  public class FishInventory
  {
    private List<Fish> _fishes;

    public List<Fish> GetFishes()
    {
      return new List<Fish>(_fishes);
    }
    
    public void TakeInFish(Fish fish)
    {
      _fishes.Add(fish);
    }

    public void TakeOutFish(int fishId)
    {
      for (int i = 0; i < _fishes.Count; i++)
      {
        if (_fishes[i].Id != fishId) 
          continue;
        
        _fishes.RemoveAt(i);
        break;
      }
    }
  }
}