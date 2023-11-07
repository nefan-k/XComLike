using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public static List<Unit> units = new List<Unit>();

    void OnEndingTurn()
    {
        foreach(Unit u in units)
        {
            u.Move();
        }
    }
}
