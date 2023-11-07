using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class SpaceForSound : MonoBehaviour
{

    public AudioSource audioSource;

    void Update()
    	{
         if (Input.GetKeyDown(KeyCode.Space))
             audioSource.Play();
}
     }
        


