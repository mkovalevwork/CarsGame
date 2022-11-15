using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _forwardSpeed = 20;
    private float _turnSpeed = 45;
    private float _horizontalInput;
    private float _forwardInput;
  
    private void FixedUpdate()
    {
        _forwardInput = Input.GetAxis("Vertical");
        _horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward  * _forwardSpeed * _forwardInput * Time.deltaTime); //forward
        transform.Rotate(Vector3.up, _turnSpeed * _horizontalInput * Time.deltaTime);   //rotate
    }
}
