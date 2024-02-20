using UnityEngine;

[CreateAssetMenu(fileName = "FishData")]
public class FishGenus : ScriptableObject
{
  public string Name { get; set; }
  public Sprite FishImage { get; set; }
  public int MinScoringWeight { get; set; }
  public string Description { get; set; }
}