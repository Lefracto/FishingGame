using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
  [SerializeField] private Slider volumeSlider;

  void Start()
  {
    AudioListener.volume = volumeSlider.value;
    volumeSlider.onValueChanged.AddListener(SetVolume);
  }

  public void SetVolume(float volume)
  {
    AudioListener.volume = volume;
  }
}