using UnityEngine;
using UnityEngine.EventSystems;

public class DraggablePanel : MonoBehaviour, IPointerDownHandler, IDragHandler
{
  private RectTransform rectTransform;
  private Canvas canvas;
  private Vector2 offset;

  private void Awake()
  {
    rectTransform = GetComponent<RectTransform>();
    canvas = GetComponentInParent<Canvas>(); // Убедитесь, что панель находится внутри Canvas
  }

  public void OnPointerDown(PointerEventData eventData)
  {
    // Преобразовываем позицию курсора из экранных координат в координаты внутри Canvas
    RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out offset);
    offset = rectTransform.anchoredPosition - offset;
  }

  public void OnDrag(PointerEventData eventData)
  {
    if (rectTransform == null)
      return;

    Vector2 position;
    if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, eventData.position, eventData.pressEventCamera, out position))
    {
      rectTransform.anchoredPosition = position + offset;
    }
  }
}