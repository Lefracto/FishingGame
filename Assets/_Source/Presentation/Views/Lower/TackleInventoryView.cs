using Core;
using UnityEngine;
using Zenject;

public class TackleInventoryView : MonoBehaviour
{
  
  //  [Inject]
  private TackleInventory _inventory;
  
  [SerializeField] private GameObject _baitsCellPrefab;
  [SerializeField] private GameObject _baitsPanelContent;
  
  
  
  void Start()
  {
  }

  
  void Update()
  {
  }
}