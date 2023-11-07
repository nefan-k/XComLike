using UnityEngine;
using System.Collections;

public class DemoScript : MonoBehaviour {
    //name of the scene you want to load
    public string scene;
	public Color loadToColor = Color.white;
	
	    void Update(){
if(Input.GetKey("space"))
{
        Initiate.Fade(scene, loadToColor, 1.0f);
    }
}
}
