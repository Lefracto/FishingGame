namespace Core
{
  public class Fish
  {
    public int Id { get; }
    public int Weight { get; }
    public FishGenus Genus { get; }

    public Fish(FishGenus genus, int weight, int id)
    {
      Genus = genus;
      Weight = weight;
      Id = id;
    }
  }
}