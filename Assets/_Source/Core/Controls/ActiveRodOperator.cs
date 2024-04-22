using UnityEngine;
using UnityEngine.UI;

namespace Core
{
  public class ActiveRodOperator : MonoBehaviour
  {
    public Slider slider1;
    public Slider slider2;
    public KeyCode increaseKeyForSlider1 = KeyCode.G;
    public KeyCode increaseKeyForSlider2 = KeyCode.H;
    public float changeRate = 0.1f;  

    void Update()
    {
      if (Input.GetKey(increaseKeyForSlider1))
      {
        slider1.value += changeRate * Time.deltaTime;
      }
      else if (slider1.value > 0)
      {
        slider1.value -= changeRate * Time.deltaTime;
      }

      if (Input.GetKey(increaseKeyForSlider2))
      {
        slider2.value += changeRate * Time.deltaTime;
      }
      else if (slider2.value > 0)
      {
        slider2.value -= changeRate * Time.deltaTime;
      }
    }
  }
}