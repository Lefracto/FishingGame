using UnityEngine;

[CreateAssetMenu(fileName = "New Food Item")]
public class FoodItem : ScriptableObject
{
  [SerializeField] private int _id;
  [SerializeField] private string _name;
  [SerializeField] private Sprite _itemIcon;
  [SerializeField] private int _countPortions;
  [SerializeField] private int _satietyPerPortion;

  public string Name
  {
    get => _name;
  }

  public Sprite ItemIcon
  {
    get => _itemIcon;
  }

  public int CountPortions
  {
    get => _countPortions;
  }

  public int SatietyPerPortion
  {
    get => _satietyPerPortion;
  }
    
  public int Id { get; set; }
}