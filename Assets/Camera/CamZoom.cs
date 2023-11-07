using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// This script is supposed to be placed on the actual camera
public class CamZoom : MonoBehaviour
{
    public float zoomAmount = 3f;           // Zoom amount
    public float zoomTime = 10f;            // Lerp time

    public float minZoomPercent = 30f;      // Minimum zoom-in percent allowed
    public float maxZoomPercent = 500f;     // Maxiumum zoom-in percent allowed

    private float _input;          // Input
    private Vector3 _newZoom;      // Target zoom
    private Vector3 _oldZoom;      // Backup zoom
    private Vector3 _defaultZoom;  // DefaultZoom

    // Start is called before the first frame update
    void Start() {
        _defaultZoom = _newZoom = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        _oldZoom = _newZoom;

        // Calculate zoom
        if(_input > 0)
            _newZoom += new Vector3(0, -zoomAmount, zoomAmount);
        else if(_input < 0)
            _newZoom -= new Vector3(0, -zoomAmount, zoomAmount);
        
        if((_defaultZoom.magnitude/_newZoom.magnitude)*100 < minZoomPercent || (_defaultZoom.magnitude/_newZoom.magnitude)*100 > maxZoomPercent)
            _newZoom = _oldZoom;

        // Calculate rotation
        transform.localPosition = Vector3.Lerp(transform.localPosition, _newZoom, Time.deltaTime * zoomTime);
    }

    // Invoked by BroadcastMessage & Updates the input
    public void OnZooming(InputValue value) => _input = value.Get<Vector2>().y;
}
