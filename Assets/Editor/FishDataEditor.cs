using UnityEditor;

namespace Editor
{
  [CustomEditor(typeof(FishGenus))]
  public class FishDataEditor : UnityEditor.Editor
  {
    private FishGenus _fish;
    private const int FISH_IMAGE_HEIGHT = 167;
    private const int FISH_IMAGE_WIDTH = 250;

    public override void OnInspectorGUI()
    {
      _fish = (FishGenus)target;
      serializedObject.Update();

      _fish.Name = EditorGUILayout.TextField("Fish Name", _fish.Name);
      _fish.MinScoringWeight = EditorGUILayout.IntField("Min Scored Weight", _fish.MinScoringWeight);
      _fish.Description = EditorGUILayout.TextField("Description of Fish", _fish.Description);
      _fish.FishImage = ItemsElementsEditor.SpriteEditor(_fish.FishImage, FISH_IMAGE_HEIGHT, FISH_IMAGE_WIDTH, "Fish");

      serializedObject.ApplyModifiedProperties();
    }
  }
}