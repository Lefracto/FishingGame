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

    public override void OnInspectorGUI()
    {
      _rod = (RodModel)target;
      serializedObject.Update();
      _rod.Visual ??= new TackleVisual();
      ItemsElementsEditor.TackleVisualEditor(_rod.Visual, ROD_IMAGE_HEIGHT, ROD_IMAGE_WIDTH, "Rod");
    }
  }
}