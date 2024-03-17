using Core;
using UnityEditor;
using UnityEngine;

namespace Editor
{
  [CustomEditor(typeof(RodModel))]
  public class RodModelEditor : UnityEditor.Editor
  {
    private RodModel _rod;
    private const int ROD_IMAGE_HEIGHT = 167;
    private const int ROD_IMAGE_WIDTH = 250;
    
    private const string MAX_WEIGHT_TEXT = "Max Weight (kg)";
    
    public override void OnInspectorGUI()
    {
      _rod = (RodModel)target;
      AssetVisualEditor.TackleModelEditor(_rod, ROD_IMAGE_HEIGHT, ROD_IMAGE_WIDTH);
      GUILayout.Space(AssetVisualEditor.POST_ICON_SPACE);
      _rod.MaxWeight = EditorGUILayout.IntField(MAX_WEIGHT_TEXT, _rod.MaxWeight);
      serializedObject.ApplyModifiedProperties();

      if (GUI.changed)
        EditorUtility.SetDirty(target);
    }
  }
}