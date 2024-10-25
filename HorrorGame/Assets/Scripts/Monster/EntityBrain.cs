using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EntityBrain : MonoBehaviour
{
    SortedDictionary<int, Goal> entityGoals = new SortedDictionary<int, Goal>();
    List<int> currentGoals = new List<int>();//hosts the weights of currentGoals that can trigger
    List<int> deadGoals = new List<int>();//hosts the weights of currentGoals that cannot trigger
    
    //Add Goals to Entity Brain
    public void AddGoal(Goal goal)
    {
        entityGoals.Add(goal.weight, goal);
    }
    
    //when called add goals to current goals list or dead goal list
    public void GoalDecide()
    {
        //check if the goal can trigger if so then add to current goal list
        for (int i = 0; i < entityGoals.Count; i++)
        {
            if (entityGoals[i].GoalTrigger())
            {
                currentGoals.Add(entityGoals[i].weight);
            }
            else //if it cant trigger add to the dead list
            {
                deadGoals.Add(entityGoals[i].weight);
            }
        }
        
        //print("current goal count: " + currentGoals.Count);
        //print("dead goal count: " + deadGoals.Count);
    }

    //sorts currentgoals to get accurate representation for weights
    public Goal SetMonsterGoal()
    {
        currentGoals.Sort();
        int pickedGoal = currentGoals[currentGoals.Max()]; //gets the highest weighted option 
        
        print("Entity Picked: " + entityGoals[pickedGoal].goalName);
        //returns the highest weighted goal back for the monster to complete
        return entityGoals[pickedGoal];
    }

    public void PrintEntityGoals()
    {
        for (int i = 0; i < entityGoals.Count; i++)
        {
            print(entityGoals[i].goalName);
        }
    }

    public void PrintCurrentGoals()
    {
        print("---------------------------------- CURRENT GOALS FOR THE ENTITY ----------------------------------");
        for (int i = 0; i < currentGoals.Count; i++)
        {

            print(entityGoals[i].goalName); //prints the goals that are in the current goal List
        }
        print("---------------------------------- CURRENT GOALS FOR THE ENTITY ----------------------------------");
    }
}
