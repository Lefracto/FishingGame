using System.Collections;
using System.Collections.Generic;
using Assets.SimpleLocalization.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class LocalizedImage : MonoBehaviour
{
  /// <summary>
  /// Localize text component.
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
    GetComponent<Image>().sprite = _localizedSprites[int.Parse(LocalizationManager.Localize(LocalizationKey))];
  }
}
