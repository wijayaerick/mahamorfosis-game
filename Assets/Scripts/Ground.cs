using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {

	private Collider2D col;
	private Rigidbody2D rb;
	
	public bool canMove = false;
	public enum GroundMovementType {LINEAR, LINEAR_BACK, LINEAR_CIRCULAR, CIRCLE};
	public GroundMovementType movementType;
	public float speed = 1;	
	public Vector3[] movementSet;
	public Vector2 center;
	private bool ascending = true;
	private int currMovement = 0;
	private float angle;

	public bool canFall = false;
	public float fallSpeed = 50f;
	public float fallTime = 0f;
	private float elapsedTimeAfterFall = 0f;
	private bool isFalling = false;
	public float activeTimeAfterFall = 10f;

	public bool canCrush = true;
	public float crushDamage = 999999;
	public bool destroyable = false;
	public float health = 5f;

	// Use this for initialization
	void Start () {
		col = GetComponent<Collider2D>();
		rb = GetComponent<Rigidbody2D>();
		rb.isKinematic = true;
		rb.constraints = RigidbodyConstraints2D.FreezeRotation;
		if (!canMove)
		{
			rb.constraints |= RigidbodyConstraints2D.FreezePositionX;
		}
	}
	
	void Update () {
		if (canMove)
		{
			if (movementType == GroundMovementType.LINEAR)
			{
				MoveLinear();
			}
			else if (movementType == GroundMovementType.LINEAR_BACK)
			{
				MoveLinearBack();
			}
			else if (movementType == GroundMovementType.LINEAR_CIRCULAR)
			{
				MoveLinearCircular();
			}
			else if (movementType == GroundMovementType.CIRCLE)
			{
				MoveCircle();
			}


		}

		if (isFalling)
		{
			elapsedTimeAfterFall += Time.deltaTime;
			if (elapsedTimeAfterFall > activeTimeAfterFall)
			{
				Destroy(gameObject);
			}
		}
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "Ground")
		{
			Physics2D.IgnoreCollision(coll.collider, col);
		}
		if (canFall && coll.gameObject.tag == "Player")
		{
			StartCoroutine("Fall");
		}
	}

	IEnumerator Fall()
	{
		yield return new WaitForSeconds(fallTime);
		isFalling = true;
		canMove = false;
		rb.isKinematic = false;
		rb.AddForce(new Vector2(0, -fallSpeed));
		yield return 0;
	}

	void MoveLinear()
	{	
		if (currMovement >= movementSet.Length)
			return;
		
		if (transform.localPosition  == movementSet[currMovement])
			currMovement++;
		
		float step = speed * Time.deltaTime;
        transform.localPosition  = Vector3.MoveTowards(transform.localPosition , movementSet[currMovement], step);
	}

	void MoveLinearBack()
	{	
		if (transform.localPosition == movementSet[currMovement])
		{
			if (ascending)
				currMovement++;
			else
				currMovement--;
		}
		if (currMovement < 0)
		{
			currMovement = 0;
			ascending = true;
		}
		else if (currMovement >= movementSet.Length)
		{
			currMovement = movementSet.Length - 1;
			ascending = false;
		}
		
		float step = speed * Time.deltaTime;
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, movementSet[currMovement], step);
	}

	void MoveLinearCircular()
	{	
		if (transform.localPosition  == movementSet[currMovement]) {
			Debug.Log(currMovement + " " + transform.localPosition );
			currMovement = (currMovement + 1) % movementSet.Length;
		}
		
		float step = speed * Time.deltaTime;
        transform.localPosition  = Vector3.MoveTowards(transform.localPosition , movementSet[currMovement], step);
	}

	void MoveCircle()
	{
		angle += speed * Time.deltaTime;
 
        var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * 2f;
        transform.localPosition = center + offset;
	}
}
