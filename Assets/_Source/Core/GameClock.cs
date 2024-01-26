using UnityEngine;
using System;
using System.Collections;
using Core;
using Unity.VisualScripting;

public class GameClock : MonoBehaviour
{
  private GameTime _currentTime;

  [SerializeField] private int _deltaUpdateMinutes;
  [SerializeField] private int _deltaUpdateHours;

  [Space(15)] [SerializeField] private int _updateCooldown;

  private Action<DayOfWeek> _onDayChanged;
  private Action _onWeekChanged;
  private Coroutine _timeUpdateCoroutine;

  public void AddOnDayChangedHandler(Action<DayOfWeek> handler)
    => _onDayChanged += handler;

  public void AddOnWeekChangedHandler(Action handler)
    => _onWeekChanged += handler;

  public void StartGameTime()
    => _timeUpdateCoroutine = StartCoroutine(UpdateTime());

  public void StopGameTime()
    => StopCoroutine(_timeUpdateCoroutine);

  private IEnumerator UpdateTime()
  {
    while (true)
    {
      yield return new WaitForSecondsRealtime(_updateCooldown);
      bool isDayChanged = false;
      _currentTime.AddHours(_deltaUpdateHours, ref isDayChanged);
      _currentTime.AddMinutes(_deltaUpdateMinutes, ref isDayChanged);

      if (!isDayChanged)
        continue;

      _onDayChanged.Invoke(_currentTime.DayOfWeek);

      if (_currentTime.DayOfWeek == DayOfWeek.Monday)
        _onWeekChanged.Invoke();
    }
  }

  public string GetFormattedTime()
    => _currentTime.ToString();

  public GameTime GetCurrentTime()
    => _currentTime.CloneViaSerialization();
}