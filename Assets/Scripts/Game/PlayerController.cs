using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float forwardSpeed = 20;
    private float turnSpeed = 45;
    private float horizontalInput;
    private float forwardInput;
  
    void FixedUpdate()
    {
        forwardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward  * forwardSpeed * forwardInput * Time.deltaTime); //forward
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);   //rotate
    }
}
