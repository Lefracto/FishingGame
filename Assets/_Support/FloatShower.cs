using UnityEngine;
using UnityEngine.UI;

public class FloatShower : MonoBehaviour
{
   [SerializeField]
   private float _value;
   private void Start()
   {
      gameObject.GetComponent<Image>().color = Color.clear;
      Invoke("Show", _value);
   }
   
   public void Show()
   {
      gameObject.GetComponent<Image>().color = Color.white;
   }
}
