using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
  [SerializeField] private AudioSource _audioSource;
  [SerializeField] private AudioClip[] _soundTracks;

  [SerializeField] private float _transitionTime = 2.0f;
  private int _currentTrackIndex = -1;

  private void Start()
  {
    Debug.Log(gameObject.name);
    SetSoundTrack(1);
  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.A))
    {
      SetSoundTrack(1);
    }
  }
  
  public void SetSoundTrack(int index)
  {
    StartCoroutine(ChangeTrack(index));
  }

  private IEnumerator ChangeTrack(int newIndex)
  {
    yield return StartCoroutine(FadeOut());

    _audioSource.clip = _soundTracks[newIndex];
    _audioSource.Play();
    yield return StartCoroutine(FadeIn());

    _currentTrackIndex = newIndex;
  }

  public void SwitchAudioMode(int mode)
  {
    AudioListener.volume = mode;
  }

  private IEnumerator FadeOut()
  {
    float startVolume = _audioSource.volume;

    while (_audioSource.volume > 0)
    {
      _audioSource.volume -= startVolume * Time.deltaTime / _transitionTime;
      yield return null;
    }

    _audioSource.Stop();
    _audioSource.volume = startVolume;
  }

  private IEnumerator FadeIn()
  {
    float targetVolume = 1.0f;
    _audioSource.volume = 0;

    while (_audioSource.volume < targetVolume)
    {
      _audioSource.volume += Time.deltaTime / _transitionTime * targetVolume;
      yield return null;
    }
  }
}