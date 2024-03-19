using UnityEngine;

namespace Presentation
{
  public class WindowVisibilityController : MonoBehaviour
  {
    [SerializeField] private Transform _inventoryPanel;

    public void ShowPanel()
    {
      _inventoryPanel.gameObject.SetActive(true);
      _inventoryPanel.position = Vector3.zero;
    }

    public void HidePanel()
    {
      _inventoryPanel.gameObject.SetActive(false);
      _inventoryPanel.position = new Vector3(1000, 1000, 0);
    }
  }
}