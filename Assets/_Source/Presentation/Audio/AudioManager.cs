using Presentation.Views.Lower;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
  [SerializeField] private AudioSource _source;
  [SerializeField] private AudioSource _dayLake;
  
  private void Update()
  {
    if (BaitSelectView.IsBase == false)
    {
      _source.volume = 0;
      _dayLake.volume = 1;
    }
    else
    {
      _dayLake.volume = 0;
      _source.volume = 1;
    }
  }
}
