using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// A patrol route for the monster to follow
/// </summary>
public class Patrol : MonoBehaviour
{
    List<Waypoint> wayPoints = new List<Waypoint>(); // Patrol points represent the path the monster will follow
    Waypoint currentWaypoint;
    private int currentWaypointIndex = 0;
    public float patrolRange;
    public Vector3 vectorMonsterToPoint;

    public Patrol(float patrolRange)
    {
        this.patrolRange = patrolRange;
    }
    
    //Adds a waypoint for the monster to seek towards
    public void AddWayPoint(Vector3 position)
    {
        Waypoint wayPoint = new Waypoint(position);
        
        wayPoints.Add(wayPoint);
    }
    
    public void PerformPatrol(Monster monster)
    {
        currentWaypoint = wayPoints[currentWaypointIndex];
        
        vectorMonsterToPoint = currentWaypoint.wayPointPosition - monster.transform.position;
        Vector3 normalizedDistanceFromPoint = vectorMonsterToPoint.normalized;
        
        if (Mathf.Abs(vectorMonsterToPoint.magnitude) < patrolRange)
        {

            currentWaypointIndex++;
            
            //checks if the monster has reached the end of the patrol to loop
            if (currentWaypointIndex == wayPoints.Count)
            {
                currentWaypointIndex = 0;
            }
            
            monster.SetIdle(true);
        }
        else
        {
            //WHERE PATHING SHOULD BE APPLIED
            monster.AddForceToMonster(normalizedDistanceFromPoint, monster.GetSpeed());
        }
    }
    
    public Waypoint GetCurrentWaypoint()
    {
        return currentWaypoint;
    }
}
