using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public string stateId;
    public bool isPhyscisRelated;

    public PlayerState(string stateId, bool isPhyscisRelated)
    {
        this.stateId = stateId;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void StateAction()
    {
        print("Player is performing an action");
    }
}
