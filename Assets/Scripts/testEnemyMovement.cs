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

    // Start is called before the first frame update
    void Start()
    {
        transform.position = spawnPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        var navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        var player = GameObject.FindWithTag("Player");
        var distance = Vector3.Distance(transform.position, player.transform.position);
        
        
        
        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }


        Vector3 randomMove = transform.right * Random.Range(-10.0f, 10.0f) + transform.forward * Random.Range(-10.0f,10.0f);
         



        if (distance > 20)
        {
            controller.Move(randomMove * speed * Time.deltaTime);
        } 
        else if (distance > 10)
        {
            navMeshAgent.SetDestination(player.transform.position);
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
            Debug.Log(collision.gameObject.name);

            if(collision.gameObject.tag == "Player")
            {
                var playerHealth = collision.gameObject.GetComponent<Health>();
                playerHealth.Adjust(-5);
            }

        }

        void OnCollisionStay(Collision collision){}
        void OnCollisionExit(Collision collision){}
        
    
}
