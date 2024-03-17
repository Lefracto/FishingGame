namespace Core
{
  public class FishingSet
  {
    public FishingSet(Rod rod)
    {
      Rod = rod;
    }
    
    public ITackle this[TackleType type]
    {
      set => GetType().GetProperty(type.ToString())?.SetValue(this, value);
      get => GetType().GetProperty(type.ToString())?.GetValue(this) as ITackle;
    }
    
    public Rod Rod { get; private set; }
    public Reel Reel  { get; private set; }
    public Line Line  { get; private set; }
    public Hook Hook  { get; private set; }
    public Bait Bait  { get; private set; }
  }
}