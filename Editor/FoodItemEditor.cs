using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FoodItem))]
public class FoodItemEditor : Editor
{
    public override void OnInspectorGUI()
    {
        FoodItem foodItem = (FoodItem)target;

        EditorGUI.BeginChangeCheck();
        foodItem._name = EditorGUILayout.TextField("Name", foodItem._name);
        foodItem._portionsCount = EditorGUILayout.IntField("Portions Count", foodItem._portionsCount);
        foodItem._satietyPerPortion = EditorGUILayout.IntField("Satiety Per Portion", foodItem._satietyPerPortion);
        foodItem._itemIcon = (Sprite)EditorGUILayout.ObjectField("Item Icon", foodItem._itemIcon, typeof(Sprite), false);
        
        if (EditorGUI.EndChangeCheck())
        {
            EditorUtility.SetDirty(foodItem);
        }
    }
}
