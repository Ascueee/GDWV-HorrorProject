using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Holds data related to a Monster entity
/// Communicates with MonsterBrain and Task
/// </summary>
public class Monster : MonoBehaviour
{
    private float maxVelocity = 2;
    private float monsterSpeed = 8;
    private float sightRange = 35;
    private Rigidbody rb;
    [SerializeField] private Animator amimController;
    [SerializeField] private List<Transform> monsterWayPoints = new List<Transform>();
    [SerializeField] private Transform monsterEyePos;
    [SerializeField] private Transform playerTarget;
    [SerializeField] private LayerMask playerMask;
    
    private Task currentTask = null; //the current task the monster has to perform
    private bool performTask;
    private bool monsterIdle = false;
    private bool canSeePlayer = false;
    
    MonsterBrain monsterBrain = new MonsterBrain();
    Patrol monsterPatrol = new Patrol(1.5f);
    private Monster monster;
    private MonsterAnimationManager monsterAnim;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        monster = GetComponent<Monster>();
        monsterAnim = GetComponent<MonsterAnimationManager>();
        
        SetMonsterTasks(); //creates the tasks and send them to the Monsterbrain
        AddWayPointsToPatrol(monsterPatrol);
    }
    
    void Update()
    {
        CanSeePlayer();
        
        if (currentTask is null)
        {
            PickTask();
        }

        if (currentTask is not null)
        {
            monsterAnim.AnimationStates(monster);//calls a cammand function from the animationManager
            PerformTask();
        }
    }
/// <summary>
/// picks a task for the monster to do
/// </summary>
    void PickTask()
    {
        currentTask = monsterBrain.SetCurrentTask();
    }

    /// <summary>
    /// performs the given task and also checks if the task is done 
    /// </summary>
    void PerformTask()
    {
        performTask = currentTask.IsActive();
        //the task is currently active so monster should perform
        if (performTask)
        {
            
            currentTask.PerformTask();
        }
        else //the task has ended so set currentTask to null
        {
            currentTask = null;
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    public void CanSeePlayer()
    {
        Vector3 playerPos = playerTarget.position;
        Vector3 playerDir = playerPos - transform.position;
        Ray sightRay = new Ray(monsterEyePos.position, playerDir);
        Debug.DrawRay(sightRay.origin, sightRay.direction * sightRange, Color.blue);

        if (Physics.Raycast(sightRay,out RaycastHit sightHit, sightRange))
        {
            if (sightHit.collider.gameObject.CompareTag("Player"))
            {
                canSeePlayer = true;
            }
            else
            {
                canSeePlayer = false;
            }
        }
    }
    
    void AddWayPointsToPatrol(Patrol monsterPatrol)
    {
        //Adds a way point position to the monster patrol class
        foreach (Transform monsterWayPoint in monsterWayPoints)
        {
            monsterPatrol.AddWayPoint(monsterWayPoint.position);
        }
    }
    
    /// <summary>
    /// Add a force in the given direction using the monster rigid body
    /// </summary>
    /// <param name="direction"></param>
    /// <param name="force"></param>
    public void AddForceToMonster(Vector3 direction, float force)
    {
        if (Mathf.Abs(rb.velocity.magnitude) > maxVelocity)
        {
            return;
        }
        
        rb.AddForce(direction * force, ForceMode.Force);
    }

    /// <summary>
    /// Creates and adds all the tasks the monster can do to the Monster brain.
    /// MonsterPatrol is a given paramater for the control task
    /// </summary>
    void SetMonsterTasks()
    {
        PatrolTask patrol = GetComponent<PatrolTask>(); //creates a patrol task where the monster will follow a set path
        IdleTask idle = GetComponent<IdleTask>();
        
        monsterBrain.AddTask(patrol); //for a base monster the base goal is patrolling
        monsterBrain.AddTask(idle);
    }
    
    public float GetMaxVelocity()
    {
        return maxVelocity;
    }
    
    public float GetSpeed()
    {
        return monsterSpeed;
    }

    public void SetIdle(bool isInIdle)
    {
        monsterIdle = isInIdle;
    }
    
    public bool GetIdle()
    {
        return monsterIdle;
    }


    public bool GetCanSeePlayer()
    {
        return canSeePlayer;
    }
    
    public Transform GetTransform()
    {
        return transform;
    }
    
    public Patrol GetPatrol()
    {
        return monsterPatrol;
    }

    public Task GetCurrentTask()
    {
        return currentTask;
    }

    public void SetCurrentTask(Task newCurrentTask)
    {
        currentTask = newCurrentTask;
    }
    
    public Rigidbody GetRigidbody()
    {
        return rb;
    }

    public Animator GetAnimatorController()
    {
        return amimController;
    }
}
