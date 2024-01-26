using UnityEngine;

public class SatiationMechanism : MonoBehaviour
{
  private const int MAX_SATIETY_LEVEL = 15;

  [SerializeField] [Range(0, MAX_SATIETY_LEVEL)]
  private int _satietyLevel;

  [SerializeField] private int _satiationDecreaseTimeSeconds;

  public int SatietyLevel()
    => _satietyLevel;


  public bool IsPlayerHungry
    => _satietyLevel == 0;

  public void StartHunger()
  {
    InvokeRepeating(nameof(DecreaseSatietyLevel), _satiationDecreaseTimeSeconds, _satiationDecreaseTimeSeconds);
  }

  public void Eat(FoodItem food)
  {
    _satietyLevel += food.SatietyPerPortion;
  }

  private void DecreaseSatietyLevel()
  {
    if (_satietyLevel > 0)
      _satietyLevel--;
  }
}