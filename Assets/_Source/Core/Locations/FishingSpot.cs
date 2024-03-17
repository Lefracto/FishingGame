using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Locations
{
  [CreateAssetMenu(fileName = "FishingSpot")]

  public class FishingSpot : ScriptableObject
  {
    private const short DEPTH_GRID_WIDTH = 28;
    private const short DEPTH_GRID_HEIGHT = 28;

    
    [field: SerializeField]
    public Sprite SpotBackGround { get; private set; }
    private readonly short[,] _depthGrid = new short[DEPTH_GRID_WIDTH, DEPTH_GRID_HEIGHT];
    
    public short this[int x, int y]
    {
      get
      {
        if (x < 0 || x >= DEPTH_GRID_WIDTH || y < 0 || y >= DEPTH_GRID_HEIGHT)
          throw new ArgumentOutOfRangeException();

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