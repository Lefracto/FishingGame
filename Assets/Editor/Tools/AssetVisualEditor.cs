using System;
using Core;
using UnityEditor;
using UnityEngine;

namespace Editor
{
  public static class AssetVisualEditor
  {
    public const int POST_ICON_SPACE = 15;

    public static void TackleModelEditor(TackleModel model, int imageHeight, int imageWidth)
    {
      string tackleType = model.GetTackleType().ToString();

      model.Visual ??= new TackleVisual();
      model.Id = EditorGUILayout.IntField("Id", model.Id);
      model.Visual.Name = EditorGUILayout.TextField(tackleType + " Name", model.Visual.Name);
      model.Visual.Description = EditorGUILayout.TextField("Description", model.Visual.Description);
      model.Visual.Icon = SpriteEditor(model.Visual.Icon, imageHeight, imageWidth, tackleType);
    }
    public static Sprite SpriteEditor(Sprite icon, int imageHeight, int imageWidth, string textPrefix = "")
    {
      GUILayout.Space(POST_ICON_SPACE);
      GUIStyle centeredStyle = new(EditorStyles.boldLabel)
      {
        alignment = TextAnchor.MiddleCenter
      };

      EditorGUILayout.LabelField(textPrefix + " Image", centeredStyle);
      
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