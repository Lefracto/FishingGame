using UnityEngine;

public class InventoryPanel : SimplePanel
{
  [SerializeField] protected RectTransform _contentObject;

  public RectTransform GetContent()
  {
    return _contentObject;
  }
}