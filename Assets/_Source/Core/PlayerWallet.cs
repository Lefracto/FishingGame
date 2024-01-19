using UnityEngine;
using UnityEngine.Events;

public class PlayerWallet : MonoBehaviour
{
  private int _amountOfMoney;

  private int AmountOfMoney
  {
    get
      => _amountOfMoney;
    set
    {
      if (value < 0)
        Debug.LogError("Attempt to set the amount of money negative value");
      
      _amountOfMoney = value;
      _onAmountOfMoneyChanged.Invoke();
    }
  }

  [SerializeField] private UnityEvent _onAmountOfMoneyChanged;

  public bool TryWriteOffMoney(int amountToWriteOff)
  {
    if (AmountOfMoney < amountToWriteOff)
      return false;

    AmountOfMoney -= amountToWriteOff;
    return true;
  }
}