using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customization : MonoBehaviour
{
    public GameObject Player;
    public Material Default;
    public Material Colour1;
    public Material Colour2;
    public Material Colour3;
    public Material Colour4;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
           
            Player.GetComponent<MeshRenderer>().material = Default;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            
            Player.GetComponent<MeshRenderer>().material = Colour1;
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            Player.GetComponent<MeshRenderer>().material = Colour2;
            
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            Player.GetComponent<MeshRenderer>().material = Colour3;
            
        }
        if (Input.GetKey(KeyCode.Alpha5))
        {
            Player.GetComponent<MeshRenderer>().material = Colour4;
           
        }

    }
}

