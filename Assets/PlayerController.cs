using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb; 
    private float movementX;
    private float movementY;
    private Vector3 movementVector;
    private Vector3 movement;

    void Start()
    {
     rb = GetComponent <Rigidbody>();    
    }

  void OnMove (InputValue movementValue)
   {
   Vector2 movementVector = movementValue.Get<Vector2>(); 
   movementX = movementVector.x; 
   movementY = movementVector.y; 
   }

    private void FixedUpdate() 
   {
   movementX = movementVector.x; 
   movementY = movementVector.y; 
   rb.AddForce(movement);
   }
}
