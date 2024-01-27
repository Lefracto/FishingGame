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
    private const int ICON_FIELD_SPACE = 15;

    public override void OnInspectorGUI()
    {
      _foodItem = (FoodItem)target;
      serializedObject.Update();

      _foodItem.Name = EditorGUILayout.TextField("Food Name", _foodItem.Name);
      _foodItem.CountPortions = EditorGUILayout.IntField("Count Portions", _foodItem.CountPortions);
      _foodItem.SatietyPerPortion = EditorGUILayout.IntField("Satiety per Portion", _foodItem.SatietyPerPortion);

      GUILayout.Space(ICON_FIELD_SPACE);
      EditorGUILayout.LabelField("Food Image", EditorStyles.boldLabel);

      // The food image at the center:
      GUILayout.BeginHorizontal();
      GUILayout.FlexibleSpace();

      _foodItem.ItemIcon = (Sprite)EditorGUILayout.ObjectField(_foodItem.ItemIcon, typeof(Sprite), false,
        GUILayout.Width(FOOD_IMAGE_WIDTH),
        GUILayout.Height(FOOD_IMAGE_HEIGHT));

      GUILayout.FlexibleSpace();
      GUILayout.EndHorizontal();

      serializedObject.ApplyModifiedProperties();
    }
  }
}