using System;
using System.Collections;
using UnityEngine;

public class SatiationMechanism : MonoBehaviour
{
  public const int MAX_SATIETY_LEVEL = 13;

  [SerializeField] [Range(0, MAX_SATIETY_LEVEL)]
  private int _satietyLevel;

  [SerializeField] private int _satiationDecreaseTimeSeconds;

  private Coroutine _satietyDecreaseCoroutine;

  private Action<int> _onHungryChanged;
  public void AddOnHungryChangedHandler(Action<int> handler)
    => _onHungryChanged += handler; 
  
  public int SatietyLevel()
    => _satietyLevel;
  
  public bool IsPlayerHungry
    => _satietyLevel == 0;

  public void StartHunger()
  {
    _onHungryChanged = i => { }; 
    _satietyDecreaseCoroutine = StartCoroutine(DecreaseSatietyLevel());
  }

  private IEnumerator DecreaseSatietyLevel()
  {
    while (true)
    {
      if (_satietyLevel > 0)
        _satietyLevel--;
      
      _onHungryChanged.Invoke(_satietyLevel);
      yield return new WaitForSeconds(_satiationDecreaseTimeSeconds);
    }
  }

  public void IncreaseSatietyLevel(int satietyUnits)
  {
    _satietyLevel += satietyUnits;
    _onHungryChanged.Invoke(_satietyLevel);

  }
}