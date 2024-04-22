using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
  [SerializeField] private Slider volumeSlider;
  private const string VolumePrefKey = "volume";

  void Start()
  {
    volumeSlider.value = PlayerPrefs.GetFloat(VolumePrefKey, 0.5f); 
    AudioListener.volume = volumeSlider.value;
    volumeSlider.onValueChanged.AddListener(SetVolume); 
  }

  public void SetVolume(float volume)
  {
    AudioListener.volume = volume;
    PlayerPrefs.SetFloat(VolumePrefKey, volume); 
    PlayerPrefs.Save(); 
  }
}