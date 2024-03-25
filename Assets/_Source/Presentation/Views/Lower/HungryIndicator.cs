using System;
using System.IO;
using UnityEngine;
using Zenject;

public class HungryIndicator : MonoBehaviour
{
  private SatiationMechanism _satiation;
  [SerializeField] private GameObject[] _cells;

  [Inject]
  public void Initialize(SatiationMechanism satiation)
  {
    _satiation = satiation;

    if (_cells.Length != SatiationMechanism.MAX_SATIETY_LEVEL)
    {
      throw new ArgumentException(
        "Inconsistency between the maximum level of satiety and the number of cells in the indicator");
    }

    _satiation.StartHunger();
    _satiation.AddOnHungryChangedHandler(UpdateIndicator);
  }

  private void UpdateIndicator(int newSatiationLevel)
  {
    for (int i = 0; i < _cells.Length; i++)
      _cells[i].SetActive(i < newSatiationLevel);
  }
}