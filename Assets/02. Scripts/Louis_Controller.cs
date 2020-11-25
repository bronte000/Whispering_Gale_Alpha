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
    private bool back;

    private float x;
    private float z;
    private bool stop;

    // Start is called before the first frame update
    void Start()
    {
        
        rotation = 0.0f;
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        walking = false;
        back = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {

            x = Input.GetAxis("Horizontal"); z = Input.GetAxis("Vertical");

            stop = (x == 0) && (z == 0);

            //rotation
            transform.Rotate(0, x*5, 0);

            //stop
            if (stop)
            {
                if (walking) animator.SetBool("IsWalk", false);
                if (back) animator.SetBool("GoBack", false);
                walking = false;
                back = false;
            }
            else
            {
                if (!walking && z >= 0)
                {
                    if (back)
                    {
                        animator.SetBool("GoBack", false);
                        back = false;
                    }
                    animator.SetBool("IsWalk", true);
                    walking = true;
                }
                if (!back && z < 0)
                {
                    if (walking)
                    {
                        animator.SetBool("IsWalk", false);
                        walking = false;
                    }
                    animator.SetBool("GoBack", true);
                    back = true;
                }

            }
        }
        
        WalkAndRun();
    }

    void WalkAndRun()
    {
        if (animator.GetBool("IsWalk") == true)
        {
            if (Input.GetKey(KeyCode.LeftShift))
                animator.SetBool("IsRun", true);
        }
        else
        {
            animator.SetBool("IsRun", false);
        }
    }

}
