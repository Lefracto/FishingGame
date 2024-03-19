using System.Collections.Generic;
using System.Linq;

namespace Core
{
  public class FishInventory
  {
    private List<Fish> _fishes;

    public FishInventory()
    {
      _fishes = new List<Fish>();
    }
    
    public List<Fish> GetFishes()
    {
      return new List<Fish>(_fishes);
    }
    
    public void TakeInFish(Fish fish)
    {
      _fishes.Add(fish);
    }

    public Fish GetFish(int id)
    {
      return _fishes.FirstOrDefault(fish => fish.Id == id);
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