using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public Transform clock;
    public SunMovement movement;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("clock"))
        {
            movement.ChangePosition();
        }
    }
    
    void Update()
    {
        
    }
}
