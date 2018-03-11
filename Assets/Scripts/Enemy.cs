using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Enemy : MonoBehaviour {

    public int curHealth;
    public int maxHealth = 60;
	public int damage = 1;

    public float distance = 0f;
    public float wakeRange = 5f;

    protected bool awake = false;
	protected Player player;

    public Animator anim;

	public bool canShoot;
	public float shootRange = 3.5f;
	public float shootInterval = 0.5f;
    public float bulletSpeed = 10f;
	public float bulletMaxDistance = 30f;
    protected float bulletTimer;
	public GameObject bullet;
	protected Transform shootPoint;

    public virtual void Awake ()
    {
        anim = GetComponent<Animator>();
    }

	public virtual void Start ()
    {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		shootPoint = GetComponentInChildren<Transform>();
        curHealth = maxHealth;
	}
	
	public virtual void Update ()
    {
        anim.SetBool("awake", awake);
        RangeCheck();

		if (distance < shootRange && canShoot)
        {
            Attack();
        }

		if (player.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (curHealth <= 0)
        {
            Destroy(gameObject);
        }

	}

    public void RangeCheck()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < wakeRange)
        {
            awake = true;
        }
        if (distance > wakeRange)
        {
            awake = false;
        }
    }

    public virtual void Attack()
	{
		bulletTimer += Time.deltaTime;
        if (bulletTimer >= shootInterval)
        {
            Vector2 direction = player.transform.position - transform.position;
            direction.Normalize();

            GameObject bulletClone;
            bulletClone = Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation);
            bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
            bulletTimer = 0;
        }
	}

    public virtual void Damage (int damage)
    {
        curHealth -= damage;
        GetComponent<Animation>().Play("Player_Damaged");
    }

    public virtual void OnCollisionEnter2D (Collision2D col)
    {
		if (col.gameObject.tag == "Player")
		{
			player.Damage(damage);
			

			if (player.transform.localScale.x > 0) {
				StartCoroutine(player.Knockback(0.02f, new Vector2(-200, 200)));
			}
			else {
				StartCoroutine(player.Knockback(0.02f, new Vector2(200, 200)));
			}
		}
    }
}
