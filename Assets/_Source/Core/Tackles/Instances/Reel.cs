using UnityEngine;

namespace Core
{
  public class Reel
  {
    public ReelModel Model { get; set; }
    
    [field: Range(0, 1)]
    public float WearLevel { get; private set; }

    public static Reel CreateReel(TackleModel rodModel)
    {
      Reel reel = new()
      {
        WearLevel = 1,
        Model = rodModel as ReelModel
      };
      return reel;
    }
  }
}