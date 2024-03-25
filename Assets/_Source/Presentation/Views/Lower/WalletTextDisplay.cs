using TMPro;
using UnityEngine;
using Zenject;

public class WalletTextDisplay : MonoBehaviour
{
  [SerializeField] private TMP_Text _walletText;
  [SerializeField] private string _moneyPostfix;
  
  private Wallet _wallet;


  [Inject]
  public void Initialize(Wallet wallet)
  {
    _wallet = wallet;
    _wallet.AddOnMoneyChangedHandler(UpdateWalletText);
    // For updating the wallet text on the first start
    _wallet.AddMoney(0);
  }
  private void UpdateWalletText(int newAmount)
  {
    _walletText.text = newAmount + _moneyPostfix;
  }
}