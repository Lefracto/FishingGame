using System.Collections;
using UnityEngine;

public class SatiationMechanism : MonoBehaviour
{
  private const int MAX_SATIETY_LEVEL = 15;

  [SerializeField] [Range(0, MAX_SATIETY_LEVEL)]
  private int _satietyLevel;

  [SerializeField] private int _satiationDecreaseTimeSeconds;

  private Coroutine _satietyDecreaseCoroutine;

  public int SatietyLevel()
    => _satietyLevel;
  
  public bool IsPlayerHungry
    => _satietyLevel == 0;

  public void StartHunger()
  {
    _satietyDecreaseCoroutine = StartCoroutine(DecreaseSatietyLevel());
  }

  private IEnumerator DecreaseSatietyLevel()
  {
    while (true)
    {
      if (_satietyLevel > 0)
        _satietyLevel--;

      yield return new WaitForSeconds(_satiationDecreaseTimeSeconds);
    }
  }

  public void IncreaseSatietyLevel(int satietyUnits)
  {
    _satietyLevel += satietyUnits;
  }
}