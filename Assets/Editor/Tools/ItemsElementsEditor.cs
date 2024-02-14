using Core;
using UnityEditor;
using UnityEngine;

namespace Editor
{
  public static class ItemsElementsEditor
  {
    private const int ICON_FIELD_SPACE = 15;

    public static void TackleVisualEditor(TackleVisual visual, int imageHeight, int imageWidth, string tackleType)
    {
      visual.Id = EditorGUILayout.IntField("Id", visual.Id);
      visual.Name = EditorGUILayout.TextField(tackleType + " Name", visual.Name);
      visual.Description = EditorGUILayout.TextField("Description", visual.Description);
      
      visual.Icon = SpriteEditor(visual.Icon, imageHeight, imageWidth, tackleType);
    }
    public static Sprite SpriteEditor(Sprite icon, int imageHeight, int imageWidth, string textPrefix = "")
    {
      GUILayout.Space(ICON_FIELD_SPACE);

      EditorGUILayout.LabelField(textPrefix + " Image", EditorStyles.boldLabel);
      
      GUILayout.BeginHorizontal();
      GUILayout.FlexibleSpace();

      icon = (Sprite)EditorGUILayout.ObjectField(icon, typeof(Sprite), false,
        GUILayout.Width(imageWidth),
        GUILayout.Height(imageHeight));

      GUILayout.FlexibleSpace();
      GUILayout.EndHorizontal();
      return icon;
    }
  }
}