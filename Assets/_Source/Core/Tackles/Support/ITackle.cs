namespace Core
{
  public interface ITackle
  {
    public int Id { get; }
    public TackleModel GetModel();
  }
}