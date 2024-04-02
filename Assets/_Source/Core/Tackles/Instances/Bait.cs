using UnityEngine;

namespace Core
{
  public class Bait : ITackle
  {
    public int Id { get; }

    private readonly BaitModel _model;

    public Bait(TackleModel model, int id)
    {
      Id = id;
      _model = model as BaitModel;
      if (_model != null) Count = _model.CountInPack;
    }

    public TackleModel GetModel()
      => _model;

    public int Count;
  }
}