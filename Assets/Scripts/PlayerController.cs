using System;
using UnityEngine;


public class PlayerController : MonoBehaviour {

    // Attributes
    private CharacterController cc;

    // Moving and Jumping
    private float jumpSpeed = 10.0F;
    public float gravity = 12.0F;
    private Vector3 moveDirection = Vector3.zero;
    private bool canDoubleJump = true;
    private float yTemp = 0;

    // Use this for initialization
    void Start () {
        cc = GetComponent<CharacterController>();
    }

    void Update () {

        // Move and Jump
        if (cc.isGrounded)
        {
            canDoubleJump = true;
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= Globals.player.status.speed;
            if (Input.GetKeyDown("z"))
                moveDirection.y = jumpSpeed;

        } else
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), yTemp, 0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection.x *= Globals.player.status.speed;
            if (canDoubleJump)
            {
                if (Input.GetKeyDown("z"))
                {
                    moveDirection.y = jumpSpeed;
                    canDoubleJump = false;
                }
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        yTemp = moveDirection.y;
        cc.Move(moveDirection * Time.deltaTime);
 
    }


    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Debug.Log("Player collides plaform");
        
    }
}
