using UnityEditor;
using UnityEngine;

namespace Editor
{
  [CustomEditor(typeof(FishData))]
  public class FishDataEditor : UnityEditor.Editor
  {
    private FishData _fish;
    private const int FISH_IMAGE_HEIGHT = 167;
    private const int FISH_IMAGE_WIDTH = 250;
    private const int ICON_FIELD_SPACE = 15;

    public override void OnInspectorGUI()
    {
      _fish = (FishData)target;
      serializedObject.Update();

      _fish.Name = EditorGUILayout.TextField("Fish Name", _fish.Name);
      _fish.MinScoringWeight = EditorGUILayout.IntField("Min Scored Weight", _fish.MinScoringWeight);
      _fish.Description = EditorGUILayout.TextField("Description of Fish", _fish.Description);

      GUILayout.Space(ICON_FIELD_SPACE);
      EditorGUILayout.LabelField("Fish Image", EditorStyles.boldLabel);

      // The fish image at the center:
      GUILayout.BeginHorizontal();
      GUILayout.FlexibleSpace();
      
      _fish.FishImage = (Sprite)EditorGUILayout.ObjectField(_fish.FishImage, typeof(Sprite), false,
        GUILayout.Width(FISH_IMAGE_WIDTH),
        GUILayout.Height(FISH_IMAGE_HEIGHT));
      
      GUILayout.FlexibleSpace();
      GUILayout.EndHorizontal();

      serializedObject.ApplyModifiedProperties();
    }
  }
}