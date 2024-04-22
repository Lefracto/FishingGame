using System;
using Newtonsoft.Json;
using UnityEngine;


[Serializable]
public class Wallet : ISavable
{
  // For serialization
  public Wallet()
  {
    _onAmountOfMoneyChanged = i => { };
  }

  private const string WALLET_SAVE_PATH = "Wallet.json";

  private int _amountOfMoney;
  private Action<int> _onAmountOfMoneyChanged;

  [JsonProperty]
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

  public void SaveData()
    => SavesHelper.SerializeAndSave(this, WALLET_SAVE_PATH);

  public void LoadData()
  {
    try
    {
      _amountOfMoney = SavesHelper.LoadAndDeserialize<Wallet>(WALLET_SAVE_PATH).AmountOfMoney;
      _onAmountOfMoneyChanged.Invoke(_amountOfMoney);
    }
    catch (Exception)
    {
      SaveData();
    }
  }
}