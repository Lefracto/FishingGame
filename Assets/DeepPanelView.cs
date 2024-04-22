using UnityEngine;

public class DeepPanelView : MonoBehaviour
{
  public void ShowPanel()
  {
    transform.position = new Vector3(0, 0, 67);
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.P))
      ShowPanel();
  }

  public void ClosePanel()
  {
    transform.position = new Vector3(3000, 3000, 0);
  }
}