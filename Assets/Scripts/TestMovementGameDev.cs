using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TestMovementGameDev : MonoBehaviour
{

    //public NavMeshAgent navMeshAgent;

    public CharacterController controller;
    public Animator animator;

    public Transform playerSpawnPos;
    
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;



    // Start is called before the first frame update
    void Start()
    {
        
        //navMeshAgent = GetComponent<NavMeshAgent>();
        transform.position = playerSpawnPos.position;
        
       
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }
        

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if(!Input.anyKey)
        {
            animator.SetBool("isRunning", false);
        }
        else if (controller.velocity.x > 0)
        {
            animator.SetBool("isRunning", true);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    
    
    
    
    
    
    
    
    
    }
}
