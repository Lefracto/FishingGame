using UnityEngine;

public class ContinuousMovement : MonoBehaviour
{
  public Vector3 direction = Vector3.forward;
  public float speed = 2.0f;


  void Update()
  {
    if (Input.GetKey(KeyCode.G) || Input.GetKey(KeyCode.H))
    {
      transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
    }
  }

  public void SetDirection(Vector3 newDirection)
  {
    direction = newDirection;
  }
}