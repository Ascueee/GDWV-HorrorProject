using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [Header("Camera Vars")]
    [SerializeField] private float sensX;
    [SerializeField] private float sensY;
    [SerializeField] private float offSet;

    [Header("Camera Componenets")] 
    [SerializeField] private Transform playerObj;
    [SerializeField] private Transform playerModel;
    [SerializeField] private Transform orientation;
    private float xRotation;
    private float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMouseInput();
    }
    
    void PlayerMouseInput()
    {
        var mouseRotationX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        var mouseRotationY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseRotationX;
        xRotation -= mouseRotationY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        playerObj.rotation = Quaternion.Euler(0, yRotation, 0);

        var playerModelRotation = offSet + yRotation;
        playerModel.rotation = Quaternion.Euler(0, playerModelRotation, 0);
    }
}
