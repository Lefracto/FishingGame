using UnityEngine;

public class RandomSmoothMovement : MonoBehaviour
{
  public float radius = 5.0f;
  public float intensity = 1.0f; 
  public float moveDuration = 2.0f;
  public float speed;
  
  private Vector3 originalPosition;
  private Vector3 targetPosition;
  private float timer;

  void Start()
  {
    originalPosition = transform.localPosition;
    targetPosition = originalPosition; 
    StartRandomMovement();
  }

  public void StartRandomMovement()
  {
    GetComponent<Animator>().enabled = false;
    SetNewTargetPosition();
  }

  void Update()
  {
    if (timer < moveDuration)
    {
      transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, Time.deltaTime / moveDuration * speed);
      timer += Time.deltaTime;
    }
    else
    {
      SetNewTargetPosition();
    }
  }

  private void SetNewTargetPosition()
  {
    timer = 0;
    float randomX = Random.Range(-radius, radius) * intensity;
    float randomY = Random.Range(-radius, radius) * intensity;
    targetPosition = originalPosition + new Vector3(randomX, randomY, 0);
  }
}