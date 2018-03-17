using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlying : Enemy {

	public float flyingSpeed;

	// Use this for initialization
    public override void Awake ()
    {
        base.Awake();
    }

	public override void Start ()
    {
		base.Start();
	}
	
	public override void Update ()
    {
        anim.SetBool("awake", awake);
        RangeCheck();

		if (distance < shootRange && canShoot)
        {
            Attack();
        }

		if (player.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

		transform.position += Vector3.left * Time.deltaTime * flyingSpeed;

        if (curHealth <= 0)
        {
            Destroy(gameObject);
            Die();
        }
	}

	public override void Attack() 
	{
		bulletTimer += Time.deltaTime;
        if (bulletTimer >= shootInterval)
        {
            Vector2 direction = new Vector2(0,-1);

            GameObject bulletClone;
            bulletClone = Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation);
            bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
            bulletTimer = 0;
        }
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
