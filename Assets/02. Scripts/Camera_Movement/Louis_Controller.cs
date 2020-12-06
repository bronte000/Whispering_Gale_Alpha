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
    private bool back;

    private float x;
    private float z;

    [SerializeField]
    private DialogueTrigger BarrierD;

    void Awake()
    {

        rotation = 0.0f;
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        walking = false;
        running = false;
        back = false;
    }
    

    // Update is called once per frame
    void Update()
    {
     //   if (controller.isGrounded)
     //   {

            x = Input.GetAxis("Horizontal"); z = Input.GetAxis("Vertical");
            

            //rotation
            transform.Rotate(0, 5*x, 0);

            //walk
            if (z <= 0 && walking)
            {
                animator.SetBool("IsWalk", false);
                walking = false;
            }
            if (z > 0 && !walking) { 
                animator.SetBool("IsWalk", true);
                walking = true;
            }
            
            //back
            if (z < 0 && !back)
            {
                animator.SetBool("GoBack", true);
                back = true;
            }
            if (z>=0 && back)
            {
                animator.SetBool("GoBack", false);
                back = false;
            }
   //     }
        
        WalkAndRun();
    }

    void WalkAndRun()
    {
        if (walking && !running && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
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

    public void Stop()
    {
        walking = false;
        running = false;
        back = false;
        animator.SetBool("IsRun", false);
        animator.SetBool("GoBack", false);
        animator.SetBool("IsWalk", false);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collide");
        if (collision.gameObject.layer == 9)    // 9 is barrier
        {
            BarrierD.TriggerDialogue();
        }
    }
    

}
