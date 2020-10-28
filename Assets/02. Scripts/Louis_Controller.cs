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
    private Vector3 MoveDir;
    private Vector3 RotDir;

    private float x;
    private float z;
    

    // Start is called before the first frame update
    void Start()
    {
        speed = 6.0f;
        jumpSpeed = 8.0f;
        gravity = 20.0f;
        

        MoveDir = Vector3.zero;
        RotDir = Vector3.zero;
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {

            x = Input.GetAxis("Horizontal"); z = Input.GetAxis("Vertical");
            MoveDir = new Vector3(x, 0, z); MoveDir *= speed;

            if (MoveDir != Vector3.zero){
                animator.SetBool("IsWalk", true);
                RotDir = Vector3.Lerp(RotDir, MoveDir, 10.0f * Time.deltaTime);
                RotDir = RotDir.normalized;
                transform.rotation = Quaternion.LookRotation(RotDir);
            } else {
                animator.SetBool("IsWalk", false);
            }
        }
        if (Input.GetButton("Jump")) { 
            MoveDir.y = jumpSpeed;
        }

        MoveDir.y -= gravity * Time.deltaTime;
        controller.Move(MoveDir * Time.deltaTime);
    }

}
