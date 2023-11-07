using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CamTranslate : MonoBehaviour
{
    public float movementSpeed = 0.1f;      // Movement speed
    public float movementTime = 10f;        // Lerp time
    public float maxDistance = 30f;         // Maximum distance from the center allowed.
    
    private Vector2 _input;          // Input
    private Vector3 _newPosition;    // Target position
    private Vector3 _oldPosition;    // Backup position

    // Initialize _newPosition as the current position
    void Start() => _newPosition = transform.localPosition;

    // Main Loop
    void Update()
    {
        _oldPosition = transform.localPosition;

        // Calculate side movement (Left & Right)
        if(_input.x > 0)
            _newPosition += (transform.right * movementSpeed);
        else if(_input.x < 0)
            _newPosition += (transform.right * -movementSpeed);

        // Calculate forward movement (Forward & Backward)
        if(_input.y > 0)
            _newPosition += (transform.forward * movementSpeed);
        else if(_input.y < 0)
            _newPosition += (transform.forward * -movementSpeed);

        // Check if the player tries to move too far
        if(_newPosition.magnitude > maxDistance)
            _newPosition = _oldPosition;

        // Apply target position to current position
        transform.localPosition = Vector3.Lerp(transform.localPosition, _newPosition, Time.deltaTime * movementTime);
    }

    // Invoked by BroadcastMessage & Updates the input
    public void OnMovement(InputValue value) => _input = value.Get<Vector2>();
}
