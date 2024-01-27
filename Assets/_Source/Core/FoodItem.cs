using UnityEngine;

[CreateAssetMenu(fileName = "FoodItem")]
public class FoodItem : ScriptableObject
{
  public int Id { get; set; }
  public string Name { get; set; }
  public Sprite ItemIcon { get; set; }
  public int CountPortions { get; set; }
  public int SatietyPerPortion { get; set; }
}