namespace Core
{
  public class Fish
  {
    public int Id { get; private set; }
    public int Weight { get; private set; }
    public FishGenus Genus { get; private set; }

    public Fish(FishGenus genus, int weight, int id)
    {
      Genus = genus;
      Weight = weight;
      Id = id;
    }
  }
}