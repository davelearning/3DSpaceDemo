using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Can now select this script from Add Component in the Inspector
[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    public float speed = 6.0f;
    private CharacterController charController;

    // Now there’s a constant downward force on the player,
    // but it’s not always pointed straight down,
    // because the player object can tilt up and down with the mouse.
    public float gravity = -9.8f;

    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;
    
        // frame-rate independent movement based on time, not FPS
        movement *= Time.deltaTime;
        
        movement = transform.TransformDirection(movement);
        charController.Move(movement);
    }
}
