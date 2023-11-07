using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public string prefix = "Time: ";
    public float gameTime = 20.0F;

    private Text timerText;
    private bool isOver = false;

    void Start()
    {
    	timerText = GetComponent<Text>();
    }

    void Update()
    {
    	if(!isOver)
    	{
    		gameTime = (gameTime < Time.deltaTime) ? 0 : gameTime - Time.deltaTime;

	    	if(gameTime <= 0)
	    	{
	    		isOver = true;
	    		Pause();	
	    	}

	    	timerText.text = prefix + Mathf.Round(gameTime);
    	}
    }

    public void Pause()
    {
    	Time.timeScale = 0;
    }

    public void Resume()
    {
    	Time.timeScale = 1;
    	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
