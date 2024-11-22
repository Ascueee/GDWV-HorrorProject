using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Monster -> Gives Goals for the Monster Brain to use
/// MonsterBrain -> Returns a Task back to monster
/// State Machine for the monster deciding what tasks the monster can perform
/// </summary>
public class MonsterBrain : MonoBehaviour
{
    Dictionary<int, Task> tasks = new Dictionary<int, Task>(); //creates a dictionary of tasks the monster can use


    //Add a task to the dictionary of tasks
    public void AddTask(Task task)
    {
        tasks.Add(task.weight, task);
    }

    //gives the monster a current task
    public Task SetCurrentTask()
    {
        List<Task> activeTasks = new List<Task>(); //creates a list of tasks that the monster currently can activate
        foreach (Task task in tasks.Values)
        {
            //checks if the task is active 
            if (task.IsActive())
            {
                activeTasks.Add(task);
            }
        }

        if (activeTasks.Count != 0)
        {
            activeTasks.Sort();
            return tasks[activeTasks.Max().weight]; //returns the highest weighted task back to the monster
        }
        else
            return null;

    }
}
