using System;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

namespace Core.Locations
{
  [CreateAssetMenu(fileName = "FishingSpot")]
  [Serializable]
  public class FishingSpot : ScriptableObject
  {
    [SerializeField] private int _id;
    public int GetId => _id;

    private const short DEPTH_GRID_WIDTH = 28;
    private const short DEPTH_GRID_HEIGHT = 28;


    [field: SerializeField] public Sprite SpotBackGround { get; private set; }

    [SerializeField] private int[,] _depthGrid;
    
    public int[,] GetGrid
    {
      get { return _depthGrid; }
      set { _depthGrid = value; }
    }

    public int this[int x, int y]
    {
      get
      {
        if (x < 0 || x >= DEPTH_GRID_WIDTH || y < 0 || y >= DEPTH_GRID_HEIGHT)
          throw new ArgumentOutOfRangeException();

        if (_depthGrid == null)
        {
          _depthGrid = new int[DEPTH_GRID_WIDTH, DEPTH_GRID_HEIGHT];
        }

        return _depthGrid[x, y];
      }
      set
      {
        if (x < 0 || x >= DEPTH_GRID_WIDTH || y < 0 || y >= DEPTH_GRID_HEIGHT)
          throw new ArgumentOutOfRangeException();

        _depthGrid[x, y] = value;
      }
    }

    public List<FishBehaviour> FishesHere = new();
  }
}