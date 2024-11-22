using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleTask : Task
{
    private bool inIdle = false;
    private float idleTimer;
    public IdleTask(string taskName, int weight, Monster monster, float idleTimer) : base(taskName, weight, monster)
    {
        this.idleTimer = idleTimer;
    }
    
    public override bool IsActive()
    {
        if (monster.GetIdle() == true || monster.GetCanSeePlayer() == true)
        {
            //print("This is running");
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public override void PerformTask()
    {
        
        //dont want this to trigger when the player cant be seen 
        if (monster.GetCanSeePlayer() == true || monster.GetIdle() == true)
        {
            StartCoroutine(ResetIdle());
        }
    }


    IEnumerator ResetIdle()
    {

        yield return new WaitForSeconds(3);
        monster.SetIdle(false);
    }
}
