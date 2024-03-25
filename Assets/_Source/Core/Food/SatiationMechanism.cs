using System;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;

[Serializable]
public class SatiationMechanism
{
  public const int MAX_SATIETY_LEVEL = 14;
  public const int STANDARD_SATIETY_LEVEL = 5;

  
  [Range(0, MAX_SATIETY_LEVEL)] [JsonRequired]
  private int _satietyLevel;

  private int _satiationDecreaseTimeSeconds;

  private Task _updateSatietyTask;
  private CancellationTokenSource _cancellationToken;


  private Action<int> _onHungryChanged;

  public void AddOnHungryChangedHandler(Action<int> handler)
    => _onHungryChanged += handler;

  public SatiationMechanism(int satiationDecreaseTimeSeconds)
  {
    _satiationDecreaseTimeSeconds = satiationDecreaseTimeSeconds;
    _onHungryChanged = i => { }; 
    _satietyLevel = STANDARD_SATIETY_LEVEL;
  }
  
  public int SatietyLevel()
    => _satietyLevel;

  public bool IsPlayerHungry
    => _satietyLevel == 0;

  public void StartHunger()
  {
    _cancellationToken = new CancellationTokenSource();
    _updateSatietyTask = DecreaseSatietyLevel(_cancellationToken.Token);
  }

  private async Task DecreaseSatietyLevel(CancellationToken token)
  {
    while (!token.IsCancellationRequested)
    {
      if (_satietyLevel > 0)
        _satietyLevel--;

      _onHungryChanged.Invoke(_satietyLevel);
      // 1000 for getting milliseconds
      await Task.Delay(_satiationDecreaseTimeSeconds * 1000, token);
    }
  }

  public void IncreaseSatietyLevel(int satietyUnits)
  {
    _satietyLevel += satietyUnits;
    _onHungryChanged.Invoke(_satietyLevel);
  }
}