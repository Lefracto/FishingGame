using UnityEngine;
using System;
using System.Collections;
using Core;
using TMPro;
using Unity.VisualScripting;

public class GameClock : MonoBehaviour
{
  private GameTime _currentTime;

  [SerializeField] private int _deltaUpdateMinutes;
  [SerializeField] private int _deltaUpdateHours;

  [Space(15)] [SerializeField] private int _updateCooldown;

  private Action<DayOfWeek> _onDayChanged;
  private Action _onWeekChanged;
  private Action _onTimeChanged;

  private Coroutine _timeUpdateCoroutine;

  [Space(15)] [SerializeField] private TMP_Text _timeText;
  [SerializeField] private TMP_Text _dayOfWeekText;

  private void Start()
  {
    _currentTime = new GameTime();

    _onTimeChanged = UpdateTimeText;
    _onDayChanged = UpdateWeekDayText;
    _onWeekChanged = UpdateTimeText;

    StartGameTime();
  }

  private void UpdateTimeText()
  {
    _timeText.text = GetFormattedTime();
  }

  private void UpdateWeekDayText(DayOfWeek dayOfWeek)
    => _dayOfWeekText.text = dayOfWeek.ToString();

  public void AddOnDayChangedHandler(Action<DayOfWeek> handler)
    => _onDayChanged += handler;

  public void AddOnWeekChangedHandler(Action handler)
    => _onWeekChanged += handler;

  public void AddOnTimeChangedHandler(Action handler)
    => _onTimeChanged += handler;

  private void StartGameTime()
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
      _onTimeChanged.Invoke();
      
      if (!isDayChanged)
        continue;

      _onDayChanged.Invoke(_currentTime.DayOfWeek);

      if (_currentTime.DayOfWeek == DayOfWeek.Monday)
        _onWeekChanged.Invoke();

    }
  }

  private string GetFormattedTime()
    => _currentTime.ToString();

  public GameTime GetCurrentTime()
    => _currentTime.CloneViaSerialization();
}