using UnityEngine;

namespace Core
{
  public class Rod : ITackle
  {
    public int Id { get; }
    public Rod(TackleModel rodModel, int id)
    {
      Id = id;
      WearLevel = 1;
      _model = rodModel as RodModel;
    }
    
    private readonly RodModel _model;
    
    [field: Range(0, 1)]
    public float WearLevel { get; private set; }

    public TackleModel GetModel()
      => _model;
    
  }
}