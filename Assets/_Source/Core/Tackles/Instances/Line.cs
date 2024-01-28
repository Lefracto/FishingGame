using UnityEngine;

namespace Core
{
  public class Line
  {
    public LineModel Model { get; set; }
    
    [field: Range(0, 1)]
    public float WearLevel { get; private set; }
  }
}