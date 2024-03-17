using UnityEditor;
using UnityEngine;

namespace Editor
{
  [CustomEditor(typeof(FoodItem))]
  public class FoodItemEditor : UnityEditor.Editor
  {
    private FoodItem _foodItem;
    private const int FOOD_IMAGE_HEIGHT = 167;
    private const int FOOD_IMAGE_WIDTH = 250;

    public override void OnInspectorGUI()
    {
      _foodItem = (FoodItem)target;
      serializedObject.Update();

      _foodItem.Name = EditorGUILayout.TextField("Food Name", _foodItem.Name);
      _foodItem.CountPortions = EditorGUILayout.IntField("Count Portions", _foodItem.CountPortions);
      _foodItem.SatietyPerPortion = EditorGUILayout.IntField("Satiety per Portion", _foodItem.SatietyPerPortion);

      _foodItem.ItemIcon =
        AssetVisualEditor.SpriteEditor(_foodItem.ItemIcon, FOOD_IMAGE_HEIGHT, FOOD_IMAGE_WIDTH, "Food");
      
      serializedObject.ApplyModifiedProperties();
      
      if (GUI.changed) 
        EditorUtility.SetDirty(target); 
    }
  }
}