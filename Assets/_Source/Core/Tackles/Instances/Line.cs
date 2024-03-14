using UnityEngine;

namespace Core
{
  public class Line : ITackle
  {
    public TackleModel GetModel()
      => _model;
    
    public int Id { get; }
    private readonly LineModel _model;
    
    public Line(TackleModel rodModel, int id)
    {
      Id = id;
      WearLevel = 1;
      _model = rodModel as LineModel;
    }
    
    [field: Range(0, 1)]
    public float WearLevel { get; private set; }
  }
}