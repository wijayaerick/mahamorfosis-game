using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {

	private Collider2D col;
	private Rigidbody2D rb;
	public bool canMove = false;
	public enum GroundMovementType {LINEAR, LINEAR_BACK, CIRCLE};
	public GroundMovementType movementType;
	public float speed = 1;	
	public Vector2[] movementSet;
	public float radius = 5f;
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
		if (canFall && coll.gameObject.tag == "Player")
		{
			StartCoroutine("Fall");
		}
		else if (isFalling) {
			transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 50);
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
}
