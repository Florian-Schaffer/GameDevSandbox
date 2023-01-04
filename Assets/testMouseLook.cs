using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;
    float yRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = -Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

      
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

 
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);
        
        transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        //playerBody.Rotate(Vector3.up * mouseY);

        transform.Rotate(Vector3.up * yRotation);
        
        

    }
}
