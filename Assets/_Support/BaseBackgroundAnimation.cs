

using System;
using Core;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class BaseBackgroundAnimation : MonoBehaviour
{
  private Animator _animator;


  [SerializeField] private Sprite _night;
  [SerializeField] private Sprite _day;
  [SerializeField] private AudioManager _manager;
  
  public Image MainBack;

  [SerializeField] private GameClock _clock;

  private bool _isNight;
  private GameTime _lastTime;

  private void Start()
  {
    _animator = GetComponent<Animator>();
    _clock.AddOnTimeChangedHandler(CheckForChanging);
    _lastTime = _clock.GetCurrentTime();
  }

  private void Update()
  {
    CheckForChanging();
  }

  private void CheckForChanging()
  {
    GameTime time = _clock.GetCurrentTime();

    if (_lastTime.Hours == 5 && time.Hours == 6)
    {
      _animator.SetInteger("BackGap", 1);
      _manager.SetSoundTrack(0);
      // Night to day animation!
    }

    if (_lastTime.Hours == 23 && time.Hours == 0)
    {
      _animator.SetInteger("BackGap", 2);
      _manager.SetSoundTrack(1);

      // Day to night animation!
    }

    _lastTime = _clock.GetCurrentTime();
  }

  public void ChangeSprites()
  {
    /*
     if (MainBack.color.a != 0)
       MainBack.color.a = 0;
     else 
       MainBack.color = Color.white;
    */
  }
}