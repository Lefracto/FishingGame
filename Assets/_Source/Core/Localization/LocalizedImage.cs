using System.Collections.Generic;
using Assets.SimpleLocalization.Scripts;
using UnityEngine.UI;
using UnityEngine;
using System;

[RequireComponent(typeof(Image))]
public class LocalizedImage : MonoBehaviour
{
  /// <summary>
  /// Localize image component.
  /// </summary>
  public string LocalizationKey;

  [SerializeField] private List<Sprite> _localizedSprites;

  public void Start()
  {
    Localize();
    LocalizationManager.OnLocalizationChanged += Localize;
  }

  public void OnDestroy()
  {
    LocalizationManager.OnLocalizationChanged -= Localize;
  }

  private void Localize()
  {
    if (Int32.TryParse(LocalizationManager.Localize(LocalizationKey), out int indexOfSprite))
      GetComponent<Image>().sprite = _localizedSprites[indexOfSprite];
    else
      Debug.LogError("Localization key for image is not a number");
  }
}