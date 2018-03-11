using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour {

    public int curHealth;
    public int maxHealth = 60;

    public float distance = 0f;
    public float wakeRange = 5f;
    public float attackRange = 3.5f;
    public float shootInterval = 0.5f;
    public float bulletSpeed = 10f;
    public float bulletTimer;

    public bool awake = false;

    public GameObject bullet;
    public Transform target;
    public Animator anim;
    public Transform shootPoint;

    void Awake ()
    {
        anim = GetComponent<Animator>();
    }

	void Start ()
    {
        curHealth = maxHealth;
	}
	
	void Update ()
    {
        anim.SetBool("awake", awake);
        RangeCheck();
        
        if (distance < attackRange)
        {
            Attack();
        }

        if (target.transform.position.x > transform.position.x)
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

    void RangeCheck()
    {
        distance = Vector3.Distance(transform.position, target.position);
        if (distance < wakeRange)
        {
            awake = true;
        }
        if (distance > wakeRange)
        {
            awake = false;
        }
    }

    public void Attack()
    {
        bulletTimer += Time.deltaTime;
        if (bulletTimer >= shootInterval)
        {
            Vector2 direction = target.transform.position - transform.position;
            direction.Normalize();

            GameObject bulletClone;
            bulletClone = Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation);
            bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
            bulletTimer = 0;
        }
    }

    public void Damage (int damage)
    {
        curHealth -= damage;
        GetComponent<Animation>().Play("Player_Damaged");
    }

    void OnTriggerStay2D(Collider2D col)
    {

    }
}
