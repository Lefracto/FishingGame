using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FloatController : MonoBehaviour
{
  public Image Image;
  public Sprite ActiveFloat;
  public Animator Animator;

  public UnityEvent AddFish;
  
  public void ChangeSprite()
  {
    Image.sprite = ActiveFloat;
    Animator.SetBool("Klev", false);

  }

  void Start()
  {
    rect = GetComponent<RectTransform>();
  }

  private RectTransform rect;
  public void StartAnim()
  {
    Animator.SetBool("Klev", true);
  }

  public void Update()
  {
    if (Input.GetKeyDown(KeyCode.L))
    {
      StartAnim();
    }

    if (Input.GetKeyDown(KeyCode.Space))
    {
      GetComponent<RandomSmoothMovement>().enabled = true;
    }
    
    if (rect.position.y <= -3.1f)
    {
      FindObjectOfType<FishInventoryView>().TestFishAdding();
      Destroy(gameObject);
    }
  }
}
