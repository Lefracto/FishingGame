using UnityEngine;

public class InventoryViewHelper : ViewHelper
{
  [SerializeField] private RectTransform _contentObject;

  public RectTransform GetContent()
  {
    return _contentObject;
  }
}