namespace Core
{
  public class GroundBait : ITackle
  {
    public int Id { get; }
    private readonly GroundBaitModel _model;

    public GroundBait(TackleModel model, int id)
    {
      Id = id;
      _model = model as GroundBaitModel;
      if (_model != null) 
        Count = _model.CountInPack;
    }

    public TackleModel GetModel()
      => _model;

    public int Count;
  }
}