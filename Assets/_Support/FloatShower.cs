using System;
using UnityEngine;
using UnityEngine.UI;

public class FloatShower : MonoBehaviour
{
   [SerializeField]
   private float _value;

   private Color _previousColor;
    
   private void Start()
   {
      var imageComponent = gameObject.GetComponent<Image>();
      _previousColor = gameObject.GetComponent<Image>().color;
      gameObject.GetComponent<Image>().color = Color.clear;
      Invoke("Show", _value);
      
      if (Input.GetKey(KeyCode.O))
      {
         if (Math.Abs(transform.rotation.z - (-90)) > double.Epsilon)
         {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
         }
         else
         {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
         }
      }
   }

   void Update()
   {
      if (Input.GetKeyDown(KeyCode.Space))
      {
         transform.GetComponent<Mask>().enabled = false;
      }
   }
   
   
   public void Show()
   {
      gameObject.GetComponent<Image>().color = _previousColor;
      //gameObject.child.GetComponent<Image>().color = Color.white;
   }
}
