using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public string goalName;
    public int weight;

    
    //creates constructor for goal
    public Goal(int weight, string goalName)
    {
        this.weight = weight;
        this.goalName = goalName;
    }

    //checks if the goals parameter is triggered to be an active goal
    public virtual bool GoalTrigger()
    {
        return true;
    }

    //performs the goal action
    public virtual void PerformGoal()
    {
        print("goal triggered");
    }
    
    
}
