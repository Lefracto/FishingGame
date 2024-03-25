using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FishInventoryPanel : InventoryPanel
{
  [SerializeField] private Image _fishImage;
  [SerializeField] private TMP_Text _fishLabel;
  [SerializeField] private TMP_Text _fishDescription;
  [SerializeField] private TMP_Text _fishWeight;
  
  public Image FishImage => _fishImage;
  public TMP_Text FishLabel => _fishLabel;
  public TMP_Text FishDescription => _fishDescription;
  public TMP_Text FishWeight => _fishWeight;

}