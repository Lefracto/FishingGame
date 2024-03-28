using UnityEngine;
using UnityEngine.EventSystems;

namespace Presentation.Panels
{
  public class SpotBackPanel : MonoBehaviour, IPointerDownHandler
  {
    [SerializeField] private GameObject _prefabToSpawn;
    [SerializeField] private GameObject _rodPrefab;
    
    [SerializeField] private Canvas _canvasToSpawn;

    [SerializeField] private Vector3 _offset;
    [SerializeField] private Vector3 _rodOffset;

    
    private GameObject _currentSpawnedRod;
    private GameObject _currentSpawnedObject;
    public void OnPointerDown(PointerEventData eventData)
    {
      Vector2 mousePosition = Input.mousePosition;
      RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvasToSpawn.transform as RectTransform, mousePosition, _canvasToSpawn.worldCamera, out Vector2 localPoint);
      Vector3 worldPoint = _canvasToSpawn.transform.TransformPoint(localPoint);

      if (_currentSpawnedObject != null)
        Destroy(_currentSpawnedObject);

      if (_currentSpawnedRod != null)
        Destroy(_currentSpawnedRod);
      
      _currentSpawnedObject = Instantiate(_prefabToSpawn, worldPoint, Quaternion.identity, _canvasToSpawn.transform);
      _currentSpawnedRod = Instantiate(_rodPrefab, worldPoint, Quaternion.identity, _canvasToSpawn.transform);

      if (_currentSpawnedRod.TryGetComponent(out RectTransform rectTransform1))
        rectTransform1.anchoredPosition = new Vector2(localPoint.x, -80);
      
      if (_currentSpawnedObject.TryGetComponent(out RectTransform rectTransform))
        rectTransform.anchoredPosition = localPoint;
      
      _currentSpawnedRod.transform.position += _rodOffset;
      _currentSpawnedObject.transform.position += _offset;
      
    }
  }
}