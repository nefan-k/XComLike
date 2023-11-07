using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Ties ties;
    public Pool pool;
    public Camera camera;

    void Start()
    {
        if(camera == null)
            camera = Camera.main;
    }
}
