using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bakwan : EnemyMoving {

	public GameObject soundManager;
	public bool isSmart;

    public override void Awake()
	{
        base.Awake();
    }

	public override void Start ()
    {
		base.Start();
	}
	
	public override void Update ()
    {
        RangeCheck();

        if (awake)
        {
			if (isSmart) {
				if (player.transform.position.x < transform.position.x)
				{
					rb.AddForce(Vector2.right * speed * -1);
					transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
				} else
				{
					rb.AddForce(Vector2.right * speed * 1);
					transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
				}
			}
			else {
				rb.AddForce(Vector2.right * speed * -1);
				transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
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
        
        if (curHealth <= 0)
        {
			soundManager.GetComponents<AudioSource>()[0].Play();
			Die();
            Destroy(gameObject);
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
