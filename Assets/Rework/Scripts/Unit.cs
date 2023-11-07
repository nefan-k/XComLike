using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private bool onObject = false;
    private List<Vector2> path = new List<Vector2>();

    void OnMouseEnter()
	{
		onObject = true;
	}
	 
	void OnMouseLeave()
	{
		onObject = false;
	}

    void OnEnable()
    {
        //Add this Object to global list
        if (!Pool.units.Contains(this))
        {
            Pool.units.Add(this);
        }

        Debug.Log(Pool.units);
    }

    void OnDisable()
    {
        //Remove this Object from global list
        if (Pool.units.Contains(this))
        {
            Pool.units.Remove(this);
        }
    }

    public void Move()
    {

    }
}
