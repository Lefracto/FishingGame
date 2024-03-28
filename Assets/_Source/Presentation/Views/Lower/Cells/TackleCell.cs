using System;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.Views.Lower.Cells
{
  public class TackleCell : MonoBehaviour
  {
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _characteristics;
    [SerializeField] private Button _button;
    
    public void Initialize(string label, string characteristics, [CanBeNull] Action<int> onClick, int id)
    {
      _label.text = label;
      _characteristics.text = characteristics;
      _button.onClick.AddListener(() => onClick.Invoke(id));
    }
  }
}