using System;
using Assets.SimpleLocalization.Scripts;
using UnityEngine;
using TMPro;

public class DynamicLocalizedText : MonoBehaviour
{
  public string LocalizationKey;

  private TMP_Text _text;
  public void Start()
  {
    _text = GetComponent<TMP_Text>();
    Localize();
    LocalizationManager.OnLocalizationChanged += Localize;
  }

  public void OnDestroy()
  {
    LocalizationManager.OnLocalizationChanged -= Localize;
  }

  private void Update()
  {
    Localize();
  }

  private void Localize()
  {
    _text.text = LocalizationManager.Localize(_text.text);
  }
}