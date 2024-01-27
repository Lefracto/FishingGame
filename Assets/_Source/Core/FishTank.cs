using System.Collections.Generic;

namespace Core
{
  public class FishTank
  {
    private List<Fish> _fishes;
    
    public void AddFish(Fish fish)
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