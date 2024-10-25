using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Vars")]
    [SerializeField] float moveSpeed;
    [SerializeField] float maxSpeed;
    [Header("Player Componenets")] 
    [SerializeField] private Transform orientation;
    
    //private Vector3 moveDir;
    private float horizontalMovement;
    private float verticalMovement;

    private Vector3 moveDir;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void PlayerInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        moveDir = transform.forward * verticalMovement + transform.right * horizontalMovement;
        
    }
    void MovePlayer()
    {
        if (Mathf.Abs(rb.velocity.magnitude) >= maxSpeed)
        {
            return;
        }
        rb.AddForce(moveDir * moveSpeed, ForceMode.Force);
    }
}
