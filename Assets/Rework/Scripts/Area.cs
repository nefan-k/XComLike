using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Integrate Grid component into the code
public class Area : MonoBehaviour
{
    private Vector2 center, range, tile;

    void Start()
    {
    	center = new Vector2(
			transform.position.x, 
			transform.position.z
		);
    	range = new Vector2(
			(transform.localScale / 2.0f).x,
			(transform.localScale / 2.0f).z
		);
		tile = GetLowPos();
    }


	public Vector2 GetLowPos()
	{
		return center - range;
	}

	public Vector2 GetHighPos()
	{
		return center + range;
	}

	public Vector2 GetNextPos()
	{
		// Position to return
		Vector2 returnedTile = tile;

		// Update the tile for the next funcion call
		if(tile.x < GetHighPos().x)
			tile.x++;
		else if(tile.y< GetHighPos().y)
		{
			tile.x = GetLowPos().x;
			tile.y++;
		}
		else
			tile = GetLowPos();	// reset position if cycled through the entire area

		return returnedTile;
	}


	public bool IsObstructed(Vector2 position)
	{
		int layerMask = 1 << 8;
		layerMask = ~layerMask;

		Vector3 worldPos = new Vector3(
			position.x,
			transform.position.y,
			position.y
		);
		return Physics.Raycast(worldPos, Vector3.up, 2f, layerMask);
	}

	public bool InBounds(Vector2 position)
	{
		Vector2 locPos = position - new Vector2(center.x, center.y);

		if (!(locPos.x > -range.x && locPos.x < range.x))
			return false;
		else if (!(locPos.y > -range.y && locPos.y < range.y))
			return false;

		return true;
	}
}
