using System;
using UnityEngine;

namespace Core
{
  [Serializable]
  public struct BaitConfig
  {
    public ushort BaitModelId;
    [Range(1, 100)] public byte AttractionLevel;
  }
}