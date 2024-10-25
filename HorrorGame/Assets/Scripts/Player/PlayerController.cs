using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//A Singleton that updates the player regarding input
public class PlayerController : MonoBehaviour
{
    //private Vector3 moveDir;
    private float horizontalMovement;
    private float verticalMovement;
    private float playerStamina = 1000;
    private float playerCD = 3;
    
    private string stateId;
    
    // Update is called once per frame
    void Update()
    {
        UpdatePlayerInput();

        if (playerStamina < 0)
        {
            Invoke("ResetStamina",  3);
        }
    }
    
    
    //checks what key the player is pressing
    public string UpdatePlayerInput()
    {
        
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");
        
        if ((horizontalMovement != 0 || verticalMovement != 0) && Input.GetKey(KeyCode.LeftShift) && playerStamina > 0)
        {
            playerStamina--;//decremenets the stamina
            print("sprinting");
            return "sprinting";
        }
        else if(horizontalMovement != 0 || verticalMovement != 0)
        {
            return "walking";
        }
        else
        {
            return "idle";
        }
    }

    public float GetPlayerStamina()
    {
        return playerStamina;
    }

    public float GetHorizontalMovement()
    {
        return horizontalMovement;
    }

    public float GetVerticalMovement()
    {
        return verticalMovement;
    }

    void ResetStamina()
    {
        playerStamina = 100;
    }
}
