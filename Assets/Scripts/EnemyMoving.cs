using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : Enemy {
    protected Rigidbody2D rb;
    public float speed;
    public float maxSpeed;
    // Use this for initialization
    public override void Awake ()
    {
        base.Awake();
    }

	public override void Start ()
    {
		base.Start();
        rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	public override void Update ()
    {
        base.Update();
        if (awake)
        {
            if (player.transform.position.x < transform.position.x)
            {
                rb.AddForce(Vector2.right * speed * -1);
            } else
            {
                rb.AddForce(Vector2.right * speed * 1);
            }
            
            if (rb.velocity.x > maxSpeed)
            {
                rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
            }
            if (rb.velocity.x < -maxSpeed)
            {
                rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
            }
        }
        

    }

	public override void Attack() 
	{
		base.Attack();
	}

	public override void OnCollisionEnter2D (Collision2D col)
	{
		base.OnCollisionEnter2D(col);
	}

	public override void Die()
    {
        base.Die();
    }
}
