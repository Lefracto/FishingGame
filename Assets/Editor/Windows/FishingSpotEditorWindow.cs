﻿using Core.Locations;
using UnityEditor;
using UnityEngine;
using System;
using Random = System.Random;


namespace Editor.Windows
{
  public class FishingSpotEditorWindow : EditorWindow
  {
    //[Header("Tech Setting")]
    private FishingSpot _fishingSpot;
    private Vector2 _imageDisplaySize = new(256, 725); // Image Scale = _imageDisplaySize.y

    private Vector2Int _gridSize = new(28, 28);

    // private short[,] _gridNumbers; 
    private int _brushSize = 1;
    private short _currentDepth = 14;

    private bool _showBrush = true;
    private bool _showToolsPanel = true;
    private bool _paintingMode = true;


    [MenuItem("Window/Fishing Spot Editor")]
    public static void ShowWindow()
    {
      GetWindow<FishingSpotEditorWindow>("Fishing Spot Editor");
    }

    private SerializedObject obj;

    private void OnGUI()
    {
      if (_fishingSpot != null)
      {
        obj = new SerializedObject(_fishingSpot);
      }

      obj?.Update();

      EditorGUILayout.BeginHorizontal();

      if (_showToolsPanel)
      {
        EditorGUILayout.BeginVertical(GUILayout.Width(250));
        GUILayout.Label("Fishing Spot Editor", EditorStyles.boldLabel);
        GUILayout.Space(4);
        GUILayout.Label("Functional Settings", EditorStyles.boldLabel);

        _fishingSpot =
          (FishingSpot)EditorGUILayout.ObjectField("Fishing Spot", _fishingSpot, typeof(FishingSpot), false);
        _imageDisplaySize.y = EditorGUILayout.FloatField("Image Display Scale", _imageDisplaySize.y);

        GUILayout.Space(5);

        GUILayout.Label("Fishing Spot Editor", EditorStyles.boldLabel);

        _showBrush = EditorGUILayout.Toggle("Show Brush", _showBrush);
        _currentDepth = (short)EditorGUILayout.Slider("Depth", _currentDepth, 0, 500);
        _brushSize = EditorGUILayout.IntSlider("Brush Size", _brushSize, 1, 10);
        GUILayout.Space(3);
        if (GUILayout.Button(_paintingMode ? "Setting Deep Mode" : "Setting Unavailable Cells Mode"))
          _paintingMode = !_paintingMode;

        if (GUILayout.Button("Generate Depth Grid"))
        {
          GenerateDepthGrid();
        }

        EditorGUILayout.EndVertical();
        GUILayout.Box("", GUILayout.ExpandHeight(true), GUILayout.Width(2));
      }

      GUILayout.Space(10);

      if (GUILayout.Button(_showToolsPanel ? "<<" : ">>", GUILayout.Width(30), GUILayout.Height(30)))
        _showToolsPanel = !_showToolsPanel;


      EditorGUILayout.BeginVertical(GUILayout.ExpandWidth(true),
        GUILayout.ExpandHeight(true)); // Область рисования с расширением по ширине и высоте

      if (_fishingSpot != null && _fishingSpot.SpotBackGround != null)
      {
        GUILayout.Space(10);

        Rect spriteRect = GUILayoutUtility.GetRect(_imageDisplaySize.x, _imageDisplaySize.y);
        GUI.DrawTexture(spriteRect, _fishingSpot.SpotBackGround.texture, ScaleMode.ScaleToFit);

        DrawGrid(spriteRect);

        if (_showBrush)
          DrawBrushIndicator(spriteRect);
      }

      EditorGUILayout.EndVertical();
      EditorGUILayout.EndHorizontal();

      if (_fishingSpot != null)
      {
        EditorUtility.SetDirty(_fishingSpot);
      }
      obj?.ApplyModifiedProperties();
    }

    private void DrawGrid(Rect spriteRect)
    {
      if (_fishingSpot == null || _fishingSpot.SpotBackGround == null)
        return;

      float textureWidth = _fishingSpot.SpotBackGround.texture.width;
      float textureHeight = _fishingSpot.SpotBackGround.texture.height;
      float textureScaleWidth = spriteRect.width / textureWidth;
      float textureScaleHeight = spriteRect.height / textureHeight;
      float scale = Mathf.Min(textureScaleWidth, textureScaleHeight);
      float scaledTextureWidth = scale * textureWidth;
      float scaledTextureHeight = scale * textureHeight;
      float offsetX = (spriteRect.width - scaledTextureWidth) * 0.5f;
      float offsetY = (spriteRect.height - scaledTextureHeight) * 0.5f;
      float cellWidth = scaledTextureWidth / _gridSize.x;
      float cellHeight = scaledTextureHeight / _gridSize.y;

      for (int x = 0; x < _gridSize.x; x++)
      {
        for (int y = 0; y < _gridSize.y; y++)
        {
          Rect cellRect = new Rect(spriteRect.x + offsetX + x * cellWidth,
            spriteRect.y + offsetY + y * cellHeight,
            cellWidth, cellHeight);

          if ((Event.current.type == EventType.MouseDown || Event.current.type == EventType.MouseDrag) &&
              cellRect.Contains(Event.current.mousePosition))
          {
            ApplyBrush(x, y);
            Event.current.Use();
          }

          EditorGUI.DrawRect(cellRect, new Color());

          if (_fishingSpot[x, y] != -1)
          {
            Handles.DrawSolidRectangleWithOutline(cellRect, new Color(0, 0, 0, 0), Color.gray);
            GUIStyle numberStyle = new(GUI.skin.label) { alignment = TextAnchor.MiddleCenter };
            GUI.Label(cellRect, _fishingSpot[x, y].ToString(), numberStyle);
          }
        }
      }
    }

    private void GenerateDepthGrid()
    {
      for (int x = 0; x < _gridSize.x; x++)
      {
        for (int y = 0; y < _gridSize.y; y++)
        {
          if (_fishingSpot[x, y] != -1)
          {
            Debug.Log(CalculateDepth(x, y));
            _fishingSpot[x, y] = CalculateDepth(x, y);
          }
        }
      }

      Repaint();
    }

    private short CalculateDepth(int x, int y)
    {
      return (short)new Random().Next(0, 500);
    }


    private void ApplyBrush(int centerX, int centerY)
    {
      int brushRadius = _brushSize / 2;
      for (int x = Mathf.Max(centerX - brushRadius, 0); x <= Mathf.Min(centerX + brushRadius, _gridSize.x - 1); x++)
      {
        for (int y = Mathf.Max(centerY - brushRadius, 0); y <= Mathf.Min(centerY + brushRadius, _gridSize.y - 1); y++)
        {
          if (!(Vector2.Distance(new Vector2(x, y), new Vector2(centerX, centerY)) <= brushRadius))
            continue;

          if (_paintingMode)
            _fishingSpot[x, y] = _currentDepth;
          else
            _fishingSpot[x, y] = -1;
        }
      }

      EditorUtility.SetDirty(_fishingSpot); // Убедитесь, что это вызывается после изменений
      // Не нужно вызывать AssetDatabase.SaveAssets здесь, это может замедлить редактор
    }


    private void DrawBrushIndicator(Rect spriteRect)
    {
      Vector2 mousePosition = Event.current.mousePosition;

      if (!spriteRect.Contains(mousePosition))
        return;

      float textureScaleWidth = spriteRect.width / _fishingSpot.SpotBackGround.texture.width;
      float textureScaleHeight = spriteRect.height / _fishingSpot.SpotBackGround.texture.height;
      float scale = Mathf.Min(textureScaleWidth, textureScaleHeight);

      float cellWidth = (scale * _fishingSpot.SpotBackGround.texture.width) / _gridSize.x;
      float cellHeight = (scale * _fishingSpot.SpotBackGround.texture.height) / _gridSize.y;

      float ellipseWidth = _brushSize * cellWidth / 2;
      float ellipseHeight = ellipseWidth * (cellHeight / cellWidth);

      DrawEllipse(mousePosition, ellipseWidth, ellipseHeight, Color.white);
    }

    void OnDestroy()
    {
      if (_fishingSpot == null) return;

      EditorUtility.SetDirty(_fishingSpot);
      AssetDatabase.SaveAssets(); // Это помогает убедиться, что все изменения сохраняются
      AssetDatabase.Refresh();
    }

    void OnDisable()
    {
      if (_fishingSpot == null) return;

      EditorUtility.SetDirty(_fishingSpot);
      AssetDatabase.SaveAssets(); // Это помогает убедиться, что все изменения сохраняются
      AssetDatabase.Refresh();
    }

    private static void DrawEllipse(Vector2 centerPosition, float radiusX, float radiusY, Color color)
    {
      Handles.color = color;
      var points = new Vector3[360];
      float angle = 0f;

      for (int i = 0; i < 360; i++)
      {
        float radian = Mathf.Deg2Rad * angle;
        points[i] = new Vector3(centerPosition.x + Mathf.Cos(radian) * radiusX,
          centerPosition.y + Mathf.Sin(radian) * radiusY,
          0);
        angle += 1f;
      }

      for (int i = 0; i < 360 - 1; i++)
        Handles.DrawLine(points[i], points[i + 1]);

      Handles.DrawLine(points[359], points[0]);
    }
  }
}