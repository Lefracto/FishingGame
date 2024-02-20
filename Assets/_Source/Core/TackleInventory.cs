using System.Collections.Generic;
using UnityEngine;

namespace Core
{
  public class TackleInventory
  {
    private readonly List<ITackle> _tackles = new();
    
    
    
    public void AddTackle(TackleModel model)
      => _tackles.Add(TackleFactory.CreateTackle(model));
    
    public List<ITackle> GetOneTypeTackles(TackleType type)
      => _tackles.FindAll(tackle => tackle.GetModel().GetTackleType() == type);
  }
}