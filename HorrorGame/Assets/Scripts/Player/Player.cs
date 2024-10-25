using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles basic information for Player
/// </summary>
public class Player : MonoBehaviour
{
    private int playerStamina;
    private float horizontalMovement = 0;
    private float verticalMovement = 0;
    private Rigidbody rb;
    
    private string stateId;
    private bool isPhyscicsUpdate;

    private PlayerState currentState;
    private MovementState currentPhysicState;
    private PlayerController playerInput;

 
    PlayerState idleState = new PlayerState("idle", false);

    
    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        SetStateId();
        UpdateState();
        if (isPhyscicsUpdate == false)
        {
            currentState.StateAction();
        }

    }

    void FixedUpdate()
    {
        if (isPhyscicsUpdate == true)
        { 
            currentPhysicState.StateAction();
        }

    }

    void SetStateId()
    {
        stateId = playerInput.UpdatePlayerInput();
        horizontalMovement = playerInput.GetHorizontalMovement();
        verticalMovement = playerInput.GetVerticalMovement();
        
    }
    
    void UpdateState()
    {
        
        switch (stateId)
        {
            case "idle":
                currentState = idleState;
                isPhyscicsUpdate = idleState.isPhyscisRelated;
                break;
            case "walking":
                MovementState walkingState = new MovementState("walking", horizontalMovement, verticalMovement, 20, 5, transform, rb, true);
                currentPhysicState = walkingState;
                currentState = null;
                isPhyscicsUpdate = walkingState.isPhyscisRelated;
                break;
            case "sprinting":
                MovementState sprintState = new MovementState("walking", horizontalMovement, verticalMovement, 20, 12, transform, rb, true);
                currentPhysicState = sprintState;
                currentState = null;
                isPhyscicsUpdate = sprintState.isPhyscisRelated;
                break;
        }
    }
}
