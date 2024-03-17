using TMPro;
using UnityEngine;

public class WalletPresentation : MonoBehaviour
{
  [SerializeField] private TMP_Text _walletText;
  [SerializeField] private string _moneyPostfix;
  private Wallet _wallet;
  
  void Start()
  {
    _wallet = new Wallet(500); // Just for testing
    _wallet.AddOnMoneyChangedHandler(UpdateWalletText);
    _wallet.TryWriteOffMoney(10);
  }

  private void UpdateWalletText(int newAmount)
  {
    _walletText.text = newAmount + _moneyPostfix;
  }
}