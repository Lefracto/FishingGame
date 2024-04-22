using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeepMenuText : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _text;

    [SerializeField]
    private Slider _slider;
    
    public void UpdateValue()
    => _text.text = ((int)(_slider.value)).ToString();
}
