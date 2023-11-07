using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CamRotate : MonoBehaviour
{
    public float rotationStep = 3f;          // Rotation sensetivity
    public float rotationTime = 7f;          // Lerp time

    private float _input;               // Input
    private Quaternion _newRotation;    // Target rotation 

    // Initialize newRotation as the current rotation
    void Start() => _newRotation = transform.rotation;

    // Main Loop
    void Update()
    {
        // Ensure that we are in the "pan mode"
        if(Mouse.current.middleButton.isPressed)
        {
            // Calculate rotation
            if(_input > 0)
                _newRotation *= Quaternion.Euler(Vector3.up * rotationStep);
            else if(_input < 0)
                _newRotation *= Quaternion.Euler(Vector3.up * -rotationStep);
        }

        // Apply target rotation to current rotation
        transform.rotation = Quaternion.Lerp(transform.rotation, _newRotation, Time.deltaTime * rotationTime);
    }

    // Invoked by BroadcastMessage & Updates the input
    public void OnOrbiting(InputValue value) => _input = value.Get<Vector2>().x;
}
