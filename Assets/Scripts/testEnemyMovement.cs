using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testEnemyMovement : MonoBehaviour
{
    
    
    
    public CharacterController controller;
    public Transform spawnPos;


    public float speed = 10f;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = spawnPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        var navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        var player = GameObject.FindWithTag("PlayerBody");
        var distance = Vector3.Distance(transform.position, player.transform.position);
        
        
        
        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }


        //Random.Range(-10.0f, 10.0f);
        float randomX = 0;
        float randomZ = 0;
        Vector3 randomMove = transform.right * randomX + transform.forward * randomZ;

        float x = 0;
        float z = 1.0f;
        Vector3 targetMove = transform.right * x + transform.forward * z;

        //gravity 
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


        //ground movement and attacking
        if (distance > 20)
        {
            transform.LookAt(target);
            controller.Move(targetMove * speed * Time.deltaTime);
        } 
        else if (distance > 10)
        {
            
            navMeshAgent.SetDestination(player.transform.position);
            controller.Move(targetMove * speed * Time.deltaTime);
        }
        else if (distance > 3.0f)
        {
            //attack
        }




       /* if(navMeshAgent.isStopped)
        {
                //play anim
        }
        else
        {
                //play anim
        }  */

    }

        void OnCollisionEnter(Collision collision)
        {
            

            if(collision.gameObject.tag == "PlayerBody")
            {
                var playerHealth = collision.gameObject.GetComponent<Health>();
                playerHealth.Adjust(-5);
                Debug.Log(collision.gameObject.GetComponent<Health>());
                Debug.Log(collision.gameObject.name);
            }

        }

        void OnCollisionStay(Collision collision){}
        void OnCollisionExit(Collision collision){}
        
    
}
