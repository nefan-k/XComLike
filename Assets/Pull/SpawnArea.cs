using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
	public bool is2D = false;
    public Color GizmosColor = new Color(0.5f, 0.5f, 0.5f, 0.2f);

    public GameObject targetPrefab;
    private GameObject targetInstance;

    private Vector3 center;
    private Vector3 range;

    void Awake()
    {
    	center = transform.position;
    	range = transform.localScale / 2.0f;
    }

	void OnDrawGizmos()
	{
	    Gizmos.color = GizmosColor;
	    Gizmos.DrawCube(transform.position, transform.localScale);
	}

	void Update()
	{
		if(targetInstance == null)
			InstantiateTarget();
	}

	private Vector3 GetRandomCords(Vector3 scale)
	{
		Vector3 randLocalPos = new Vector3(
			Random.Range(-range.x, range.x),
			is2D ? center.y : Random.Range(-range.y, range.y),
			Random.Range(-range.z, range.z)
		);

		Vector3 randWorldPos = center + randLocalPos;

		return randWorldPos;
	}

	public void InstantiateTarget()
    {
    	Vector3 instancePos = GetRandomCords(targetPrefab.transform.localScale);
    	targetInstance = Instantiate(targetPrefab, instancePos, Quaternion.identity);
    }
}
