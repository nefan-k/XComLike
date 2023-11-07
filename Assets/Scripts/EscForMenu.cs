using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;

public class EscForMenu : MonoBehaviour

// verify ChangingScene.cs for public voids and the transitions
{
public GameObject EscMenu;
public float x;
public GameObject InGame;
public GameObject AtStart;

	void Start()
	{
		x = 1;

	}
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){

         if(x == 1f){
        	EscMenu.SetActive(true);
        	x -= 1f;
        	InGame.SetActive(false);
        	AtStart.SetActive(false);

       }
        else if(x == 0f){
        	EscMenu.SetActive(false);
       	x += 1f;
      	InGame.SetActive(true);
        	
       }
   }

        }
    
	}
