using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleGoal : Goal
{
    private float idleDuration;
    public bool triggerGoal = true;
    
    public IdleGoal(int weight, string goalName, float idleDuration) : base(weight, goalName)
    {
        this.idleDuration = idleDuration;
    }
    
    public override bool GoalTrigger()
    {
        if (triggerGoal == true)
            return true;
        else
            return false;
    }
    
    public override void PerformGoal()
    {
        print("performing idle");
        
        //after a few seconds call the end of the function
        triggerGoal = false;
    }
    
}
