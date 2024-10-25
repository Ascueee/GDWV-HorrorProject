using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private Transform player;
    
    List<Transform> patrolPoints = new List<Transform>();
    EntityBrain monsterBrain = new EntityBrain();
    public Goal currentGoal = null;
    

    
    // Start is called before the first frame update
    void Start()
    {
        MonsterGoals();
    }

    void Update()
    {
        SetCurrentGoal();
        PerformGoal();
    }
    

    //If the monster has no current goal run to 
    void SetCurrentGoal()
    {
        if (currentGoal == null)
        {
            monsterBrain.GoalDecide();//decides what goal to run
            //monsterBrain.PrintEntityGoals();
            
            currentGoal = monsterBrain.SetMonsterGoal();
            //monsterBrain.PrintCurrentGoals();
        }
    }

    //performs the current goals monster
    void PerformGoal()
    {
        //checks if the monster has a goal
        if (currentGoal != null)
        {
            //checks if the goal can trigger(or if it ended)
            if (currentGoal.GoalTrigger())
            {
                currentGoal.PerformGoal();
            }
            else // if not set the goal to null because the task is completed or cant trigger
            {
                currentGoal = null;
            }
        }
    }

    //sets the behavioural goals for the monster you want
    void MonsterGoals()
    {
        //GOALS
        IdleGoal idleGoal = new IdleGoal(0, "Idle",3);
        PatrolGoal patrolGoal = new PatrolGoal(1, "Patrol", patrolPoints, transform, player);
        
        monsterBrain.AddGoal(idleGoal);
    }
}
