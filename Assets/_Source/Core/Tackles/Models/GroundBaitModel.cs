namespace Core
{
  public class GroundBaitModel :  TackleModel
  {
    public override TackleType GetTackleType()
      => TackleType.GroundBait;
    
    public int CountInPack { get; set; } 
  }
}