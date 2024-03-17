using System;

namespace Core
{
  [Serializable]
  public struct GameTime
  {
    private const int MINUTES_IN_HOUR = 60;
    private const int HOURS_IN_DAY = 24;
    private int Hours { get; set; }
    private int Minutes { get; set; }

    private int _dayNumber;

    private DayOfWeek _dayOfWeek;

    public DayOfWeek DayOfWeek
    {
      get => _dayOfWeek;
      private set
      {
        _dayOfWeek = value;
        _dayNumber++;
      }
    }

    public void AddMinutes(int minutes, ref bool isDayChanged)
    {
      Minutes += minutes;

      if (Minutes < MINUTES_IN_HOUR)
        return;

      Minutes -= MINUTES_IN_HOUR;
      AddHours(1, ref isDayChanged);
    }

    public void AddHours(int hours, ref bool isDayChanged)
    {
      Hours += hours;

      if (Hours < HOURS_IN_DAY)
        return;

      if (DayOfWeek == DayOfWeek.Saturday)
        DayOfWeek = DayOfWeek.Sunday;
      else
        DayOfWeek++;

      Hours -= HOURS_IN_DAY;
      isDayChanged = true;
    }

    public override string ToString()
    {
      string hoursString = Hours < 10 ? "0" + Hours : Hours.ToString();
      string minutesString = Minutes < 10 ? "0" + Minutes : Minutes.ToString();
      return $"{hoursString}:{minutesString}";
    }
  }
}