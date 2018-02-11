using System;
using UnityEngine;


public class PlayerController : MonoBehaviour {

    // Constants
    private float jumpSpeed = 20.0F;
    private Vector3 gravityVector = new Vector3(0, -8.0F, 0);

    // Attributes
    private CharacterController cc;
    private bool canDoubleJump;

    // Use this for initialization
    void Start () {
        cc = GetComponent<CharacterController>();
        canDoubleJump = true;
    }
	
    public float speed = 6.0F;
    public float gravity = 8.0F;
    private Vector3 moveDirection = Vector3.zero;

    void Update () {

        if (cc.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetKeyDown("up"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        cc.Move(moveDirection * Time.deltaTime);
        /*
        Gravity();
        if (Input.GetKeyDown("up"))
        {
            Jump();
        }
        if (Input.GetKeyDown("left"))
        {
            MoveLeft();
        }
        if (Input.GetKeyDown("right"))
        {
            MoveRight();
        }
        if (Input.GetKeyDown("down"))
        {
            Duck();
        }*/



    }

    void Gravity()
    {
        cc.Move(gravityVector * Time.deltaTime);
    }

    void MoveLeft()
    {
        cc.Move(new Vector3(-Globals.player.status.speed, 0, 0) * Time.deltaTime);
    }

    void MoveRight()
    {
        cc.Move(new Vector3(Globals.player.status.speed, 0, 0) * Time.deltaTime);
    }

    void Jump()
    {
        Debug.Log(cc.isGrounded);
        if (cc.isGrounded)
        {
            Debug.Log("Player jumps");
            cc.Move(new Vector3(0, jumpSpeed, 0) * Time.deltaTime);

        }
    }

    void Duck()
    {

    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Debug.Log("Player collides plaform");
        
    }
}
