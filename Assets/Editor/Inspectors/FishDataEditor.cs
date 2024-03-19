using UnityEditor;
using UnityEngine;

namespace Editor
{
  [CustomEditor(typeof(FishGenus))]
  public class FishDataEditor : UnityEditor.Editor
  {
    private FishGenus _fish;
    private const int FISH_IMAGE_HEIGHT = 167;
    private const int FISH_IMAGE_WIDTH = 250;

    private const string FISH_NAME_LABEL = "Fish Name";
    private const string MIN_SCORED_WEIGHT_LABEL = "Min Scoring Weight";
    private const string DESCRIPTION_LABEL = "Description of Fish";
    private const string IMAGE_PREFIX = "Fish";
    
    public override void OnInspectorGUI()
    {
      _fish = (FishGenus)target;
      serializedObject.Update();

      _fish.Name = EditorGUILayout.TextField(FISH_NAME_LABEL, _fish.Name);
      _fish.MinScoringWeight = EditorGUILayout.IntField(MIN_SCORED_WEIGHT_LABEL, _fish.MinScoringWeight);
      _fish.FishImage = AssetVisualEditor.SpriteEditor(_fish.FishImage, FISH_IMAGE_HEIGHT, FISH_IMAGE_WIDTH, IMAGE_PREFIX);
      EditorGUILayout.Space(AssetVisualEditor.POST_ICON_SPACE);
      _fish.Description = EditorGUILayout.TextField(DESCRIPTION_LABEL, _fish.Description);
      
      serializedObject.ApplyModifiedProperties();
      
      if (GUI.changed)
        EditorUtility.SetDirty(target);
    }
  }
}