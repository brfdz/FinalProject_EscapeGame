using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 100f;

    public Transform playerBody;
    private float rotationX = 0f;
   
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        
        playerBody.Rotate(Vector3.up * mouseX);
        
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -50, 50);
        transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
    }
}
