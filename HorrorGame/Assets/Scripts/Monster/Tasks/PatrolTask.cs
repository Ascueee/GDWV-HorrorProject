using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolTask : Task
{
    private float patrolSpeed;
    private Transform target;

    
    public PatrolTask(string taskName, int weight, Monster monster) : base(taskName, weight, monster)
    {
        this.taskName = taskName;
        this.weight = weight;
        this.monster = monster;
    }
    
    public override bool IsActive()
    {
        if (monster.GetCanSeePlayer() == false || monster.GetIdle() == false)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public override void PerformTask()
    {
       monster.GetPatrol().PerformPatrol(monster);
    }


}
