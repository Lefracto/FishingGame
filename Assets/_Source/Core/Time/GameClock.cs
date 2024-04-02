using UnityEngine;
using System;
using System.Threading;
using System.Threading.Tasks;
using Core;
using TMPro;
using Unity.VisualScripting;

public class GameClock : MonoBehaviour
{
  private GameTime _currentTime;

  [SerializeField] private int _deltaUpdateMinutes;
  [SerializeField] private int _deltaUpdateHours;

  [Space(15)] 
  [SerializeField] 
  private int _updateCooldown;

  private Action<DayOfWeek> _onDayChanged;
  private Action _onWeekChanged;
  private Action _onTimeChanged;

  private Task _updateTimeTask;
  private CancellationTokenSource _cancellationTimeToken;

  [Space(15)] [SerializeField] private TMP_Text _timeText;
  [SerializeField] private TMP_Text _dayOfWeekText;
  
  public void Initialise(GameTime startTime)
  {
    _currentTime = startTime;
    _onTimeChanged = UpdateTimeText;
    _onDayChanged = UpdateWeekDayText;
    _onWeekChanged = UpdateTimeText;
    StartGameTime();
  }

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
  {
    _cancellationTimeToken = new CancellationTokenSource();
    _updateTimeTask = UpdateTime(_cancellationTimeToken.Token);
  }

  public void StopGameTime()
  {
    _cancellationTimeToken.Cancel();
    
    // Only for developing
    Debug.Log(_updateTimeTask.Status);
  }

  private async Task UpdateTime(CancellationToken token)
  {
    while (!token.IsCancellationRequested)
    {
      // 1000 for getting milliseconds
      await Task.Delay(_updateCooldown * 1000, token);
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