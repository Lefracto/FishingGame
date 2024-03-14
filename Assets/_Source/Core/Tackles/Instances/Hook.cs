using UnityEngine;

namespace Core
{
  public class Hook : ITackle
  {
    public int Id { get; }
    private readonly HookModel _model;

    public Hook(TackleModel model, int id)
    {
      Id = id;
      _model = model as HookModel;
    }

    public TackleModel GetModel()
      => _model;
    
    [field: Range(0, 1)]
    public float WearLevel { get; private set; }
  }
}