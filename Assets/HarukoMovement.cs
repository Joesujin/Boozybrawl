using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarukoMovement : MonoBehaviour
{
    float speed = 20;
    float rotSpeed = 180;
    float gravity = 8;
    float rot = 0f;
    bool picking = false;
   public Collider PickUpDetect;
   

    Vector3 moveDir = Vector3.zero;

    CharacterController controller;
    public Animator anim;

   void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        anim.SetBool("IsWalking", false);
        PickUpDetect = GetComponent<Collider>();
    }

    private void Update()
    {
        if(controller.isGrounded)
        {
            if(Input.GetKey(KeyCode.W))
            {
                anim.SetBool("IsWalking", true);
                moveDir = new Vector3(0, 0, 1);
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);
            }
           /* else
            {
                anim.SetBool("IsWalking", false);
            }*/

           if(Input.GetKeyUp (KeyCode.W))
            {
                anim.SetBool("IsWalking", false);
                moveDir = new Vector3 (0,0,0);
            }
        }
        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);

        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);
        if (movement.HoldingObject == 0)
        {// disabling the collider to pickup stuff if it is already holding an object;
            PickUpDetect.enabled = PickUpDetect.enabled;
           
        }


    }

    void GetInput()
    {
        if (controller.isGrounded)
        {
            if(Input.GetKey(KeyCode.Space))
            {
                picking = true;
                if (movement.HoldingObject == 1)
                {// disabling the collider to pickup stuff if it is already holding an object;
                    PickUpDetect.enabled = !PickUpDetect.enabled;
                }
            }
        }
    }
}
