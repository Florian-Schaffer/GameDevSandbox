using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseVerticalLook : MonoBehaviour
{

    public float speedV = 2.0f;
    public float speedH = 2.0f;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    public float minValue = -30f;
    public float maxValue = 30f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotationY += speedV * Input.GetAxis("Mouse X");
        rotationX -= speedH * Input.GetAxis("Mouse Y");

        rotationX = Mathf.Clamp(rotationX, minValue, maxValue);

        transform.eulerAngles = new Vector3(rotationX, rotationY, 0);
    }
}
