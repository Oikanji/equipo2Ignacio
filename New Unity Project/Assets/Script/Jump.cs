using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Rigidbody2D player;
    public float jumpForce;
    private bool jump;
    public bool puede_saltar = true; 
    Animator animator;
    public Rigidbody2D grounded;
    public bool isgrounded;
    

   

    void Update()
    {
        if (isgrounded == true)
        { 
       
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jump = true;

            
               
            }
        }
    }

    private void FixedUpdate()
    {
        if (jump)
        {
            player.velocity = jumpForce * Vector2.up;
            jump = false;
            isgrounded = false; 
           
        }
    }
  
}
