using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public uint pointAdd = 10;
    public uint pointSub = 5;
    public int delay = 2;
    
    private bool onObject = false;
    private bool scored = false;

    void Start()
    {
    	Destroy(gameObject, delay);
    }

    void Update()
	{
	    if(Input.GetMouseButtonDown(0))
	    {
	       	if(onObject)
	       		scored = true;

	       	Destroy(gameObject, 0.05f);
	    }
	}

	void OnMouseEnter()
	{
		onObject = true;
	}
	 
	void OnMouseLeave()
	{
		onObject = false;
	}
}
