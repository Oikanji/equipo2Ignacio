using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Rigidbody2D birdRb;
    public float jumpForce;
    private bool jump;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_STANDALONE
        if (!GameManager.deadPlayer)
        {
            if (Input.GetKey(KeyCode.A))
            {
                jump = true;
                animator.SetBool("salto", true);
            }
            else
            {
                animator.SetBool("salto", false);
            }
        }
        else
        {
            animator.SetTrigger("muerte");
        }
#endif

#if UNITY_ANDROID
        if (!GameManager.deadPlayer)
        {
            if (Input.touchCount > 0)
            {
                jump = true;
                animator.SetBool("salto", true);
            }
            else
            {
                animator.SetBool("salto", false);
            }
        }
        else
        {
            animator.SetTrigger("muerte");
        }
#endif
    }

    private void FixedUpdate()
    {
        if (jump)
        {
            birdRb.velocity = jumpForce * Vector2.up;
            jump = false;
        }
    }

    }
