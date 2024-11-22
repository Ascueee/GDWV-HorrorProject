using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour, IComparable<Task>
{
    public string taskName;
    public int weight;
    public Monster monster;
    
    public int CompareTo(Task other)
    {
        // Handle null values if necessary
        if (other == null) return 1;

        // Define comparison logic, for example by SomeProperty
        return this.taskName.CompareTo(other.taskName);
    }
    
    public Task(string taskName, int weight, Monster monster)
    {
        this.taskName = taskName;
        this.weight = weight;
        this.monster = monster;
    }

    
    //returns true if the task can be performed if not returns false
    public virtual bool IsActive()
    {
        return true;
    }

    public virtual void PerformTask()
    {
        print("doing the base task");
    }
}
