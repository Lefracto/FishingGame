using UnityEngine;

namespace Core
{
  public class Reel : ITackle
  {
    public int Id { get; }
    
    private readonly ReelModel _model;
    public TackleModel GetModel()
      => _model;
    
    [field: Range(0, 1)]
    public float WearLevel { get; private set; }

    public Reel(TackleModel rodModel, int id)
    {
      Id = id;
      WearLevel = 1;
      _model = rodModel as ReelModel;
    }
  }
}