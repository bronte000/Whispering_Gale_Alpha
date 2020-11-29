using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Louis_Controller : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    public float gravity;

    private CharacterController controller;
    private Animator animator;

    private float rotation;
    private bool walking;
    private bool running;

    private float x;
    private float z;

    // Start is called before the first frame update
    void Start()
    {
        
        rotation = 0.0f;
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        walking = false;
        running = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {

            x = Input.GetAxis("Horizontal"); z = Input.GetAxis("Vertical");
            

            //rotation
            transform.Rotate(0, 5*x, 0);

            //stop
            if (z <= 0 && walking)
            {
                if (walking) animator.SetBool("IsWalk", false);
                walking = false;
            }
            
            if (z > 0 && !walking) { 
                animator.SetBool("IsWalk", true);
                walking = true;
            }
        }
        
        WalkAndRun();
    }

    void WalkAndRun()
    {
        if (walking && !running && Input.GetKey(KeyCode.LeftShift))
        {
            running = true;
            animator.SetBool("IsRun", true);
        }
        if (running && !walking)
        {
            running = false;
            animator.SetBool("IsRun", false);
        }
    }

}
