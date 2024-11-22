using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimationManager : MonoBehaviour
{
    public void AnimationStates(Monster monster)
    {
        Task currentTask = monster.GetCurrentTask();
        currentTask = monster.GetCurrentTask();
        
        switch(currentTask.taskName)
        {
            case "Idle":
                monster.GetAnimatorController().SetBool("isWalking", false);
                break;
            case "Patrol":
                monster.GetAnimatorController().SetBool("isWalking", true);
                break;
        }
    }
}
