using UnityEngine;
using System;
using Core;
using UnityEngine.Events;

public class GameClock : MonoBehaviour
{
  private GameTime _time;
  private DayOfWeek _dayOfWeek;

  [SerializeField] private int _deltaUpdateMinutes;
  [SerializeField] private int _deltaUpdateHours;

  [Space(15)] [SerializeField] private int _updateCooldown;

  [Space(15)] [SerializeField] private UnityEvent _onDayChanged;
  [Space(10)] [SerializeField] private UnityEvent _onWeekChanged;
  
  private void StartGameTime()
  {
    InvokeRepeating(nameof(UpdateTime), 0, _updateCooldown);
  }
  
  private void UpdateTime()
  {
    if (_time.AddTime(_deltaUpdateHours, _deltaUpdateMinutes) is false) 
      return;
    
    _onDayChanged.Invoke();
    _dayOfWeek++;

    if (_dayOfWeek == DayOfWeek.Monday)
      _onWeekChanged.Invoke();
  }

  public string GetFormattedTime()
    => _time.ToString();

  public int GetDayOfWeek()
    => (int)_dayOfWeek;
}