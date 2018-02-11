using System;
using UnityEngine;


public class PlayerController : MonoBehaviour {

    // Constants
    private float jumpSpeed = 100.0F;
    private Vector3 gravityVector = new Vector3(0, -8.0F, 0);

    // Attributes
    private CharacterController cc;
    private bool canDoubleJump;

    // Use this for initialization
    void Start () {
        cc = GetComponent<CharacterController>();
        canDoubleJump = true;
    }
	
	void Update () {
        Gravity();
        if (Input.GetKey("up"))
        {
            Jump();
        }
        if (Input.GetKey("left"))
        {
            MoveLeft();
        }
        if (Input.GetKey("right"))
        {
            MoveRight();
        }
        if (Input.GetKey("down"))
        {
            Duck();
        }

        

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
