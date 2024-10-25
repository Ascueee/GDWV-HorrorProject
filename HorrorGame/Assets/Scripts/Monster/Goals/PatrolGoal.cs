using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolGoal : Goal
{
    private float distanceFromPlayerToPatrol = 1;
    List<Transform> patrolPoints = new List<Transform>();
    private Transform playerPos;
    private Transform entityPos;
    public PatrolGoal(int weight, string goalName, List<Transform> patrolPoints, Transform entity, Transform player) : base(weight, goalName)
    {
        this.patrolPoints = patrolPoints;
        this.playerPos = player;
        this.entityPos = entity;
    }

    public override bool GoalTrigger()
    {
        Vector3 distanceFromPlayer = playerPos.position - entityPos.position;
            
        if (Mathf.Abs(distanceFromPlayer.magnitude) > distanceFromPlayerToPatrol)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public override void PerformGoal()
    {
        //TO DO CREATE PATROL PERFORM GOAL FOR THE AI
        
        print("Patrolling around");
    }
    
    
}
