using System;
using UnityEngine;

public class Wallet
{
  public Wallet(int starterAmount)
  {
    _amountOfMoney = starterAmount;
    _onAmountOfMoneyChanged = i => { };
  }
  
  private int _amountOfMoney;
  private Action<int> _onAmountOfMoneyChanged;

  private int AmountOfMoney
  {
    get
      => _amountOfMoney;
    set
    {
      if (value < 0)
      {
        Debug.LogError("Attempt to set the amount of money negative value");
        return;
      }
      
      _amountOfMoney = value;
      _onAmountOfMoneyChanged.Invoke(_amountOfMoney);
    }
  }


  public void AddOnMoneyChangedHandler(Action<int> handler)
    => _onAmountOfMoneyChanged += handler;
  
  public bool TryWriteOffMoney(int amountToWriteOff)
  {
    if (AmountOfMoney < amountToWriteOff)
      return false;

    AmountOfMoney -= amountToWriteOff;
    return true;
  }

  public void AddMoney(int amountToAdd)
    => AmountOfMoney += amountToAdd;
}