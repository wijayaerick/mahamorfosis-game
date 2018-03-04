using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour {

    public int curHealth;
    public int maxHealth = 60;

    public float distance = 0f;
    public float wakeRange = 5f;
    public float shootInterval = 0.5f;
    public float bulletSpeed = 10f;
    public float bulletTimer;

    public bool awake = false;
    public bool lookingRight = true;

    public GameObject bullet;
    public Transform target;
    public Animator anim;
    public Transform shootPointLeft;
    public Transform shootPointRight;

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
        anim.SetBool("lookingRight", lookingRight);
        RangeCheck();
        if (target.transform.position.x > transform.position.x)
        {
            lookingRight = true;
        }
        else
        {
            lookingRight = false;
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

    public void Attack(bool attackingRight)
    {
        bulletTimer += Time.deltaTime;
        if (bulletTimer >= shootInterval)
        {
            Vector2 direction = target.transform.position - transform.position;
            direction.Normalize();

            if (!attackingRight)
            {
                GameObject bulletClone;
                bulletClone = Instantiate(bullet, shootPointLeft.transform.position, shootPointLeft.transform.rotation);
                bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
                bulletTimer = 0;
            } else
            {
                GameObject bulletClone;
                bulletClone = Instantiate(bullet, shootPointRight.transform.position, shootPointRight.transform.rotation);
                bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
                bulletTimer = 0;
            }
        }
    }

    public void Damage (int damage)
    {
        curHealth -= damage;
        GetComponent<Animation>().Play("Player_Damaged");
    }
}
