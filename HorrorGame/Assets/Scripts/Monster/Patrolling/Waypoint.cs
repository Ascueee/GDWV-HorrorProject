using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a point that a Monster would want to seek towards
/// </summary>
public class Waypoint
{ 
    public Vector3 wayPointPosition;

    public Waypoint(Vector3 wayPointPosition)
    {
        this.wayPointPosition = wayPointPosition;
    }
    
    
}
