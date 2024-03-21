using UnityEngine;

[CreateAssetMenu(fileName = "FishData")]
public class FishGenus : ScriptableObject
{
  [field: SerializeField] public string Name { get; set; }
  [field: SerializeField] public Sprite FishImage { get; set; }
  [field: SerializeField] public int MinScoringWeight { get; set; }
  [field: SerializeField] public string Description { get; set; }
}