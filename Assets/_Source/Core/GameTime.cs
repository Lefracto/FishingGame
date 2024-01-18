namespace Core
{
  public struct GameTime
  {
    private const int MINUTES_IN_HOUR = 60;
    private const int HOURS_IN_DAY = 24;

    private int Hours { get; set; }
    private int Minutes { get; set; }
    
    // Return true if day has changed
    public bool AddTime(int hours, int minutes)
    {
      Minutes += minutes;

      if (Minutes >= MINUTES_IN_HOUR)
      {
        Hours++;
        Minutes -= MINUTES_IN_HOUR;
      }

      Hours += hours;

      if (Hours < HOURS_IN_DAY)
        return false;

      Hours -= HOURS_IN_DAY;
      return true;
    }

    public override string ToString()
      => $"{Hours}:{Minutes}";
  }
}