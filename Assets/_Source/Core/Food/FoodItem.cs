using Newtonsoft.Json;
using UnityEngine;

[CreateAssetMenu(fileName = "FoodItem")]
public class FoodItem : ScriptableObject
{
  [field: SerializeField] public int Id { get; set; }
  [field: SerializeField] public string Name { get; set; }
  [field: SerializeField] public Sprite ItemIcon { get; set; }
  [field: SerializeField] public int CountPortions { get; set; }
  [field: SerializeField] public int SatietyPerPortion { get; set; }
}