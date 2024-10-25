using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Deals with physics related states
/// </summary>
public class MovementState : PlayerState
{
    private float horizontalMovement;
    private float verticalMovement;
    private float movementSpeed;
    private float maxSpeed;
    private Rigidbody rb;
    private Transform player;
    
    
    public MovementState(string stateId, float horizontalMovement, float verticalMovement, float movementSpeed, float maxSpeed, Transform player ,Rigidbody rb ,bool isPhyscisRelated) : base(stateId, isPhyscisRelated)
    {
        this.horizontalMovement = horizontalMovement;
        this.verticalMovement = verticalMovement;
        this.stateId = stateId;
        this.isPhyscisRelated = isPhyscisRelated;
        this.movementSpeed = movementSpeed;
        this.maxSpeed = maxSpeed;
        this.player = player;
        this.rb = rb;

    }

    public void StateAction()
    {
        Vector3 moveDir = player.forward * verticalMovement + player.right * horizontalMovement;
        
        if (Mathf.Abs(rb.velocity.magnitude) >= maxSpeed)
        {
            return;
        }
        rb.AddForce(moveDir * movementSpeed, ForceMode.Force);
    }
}
