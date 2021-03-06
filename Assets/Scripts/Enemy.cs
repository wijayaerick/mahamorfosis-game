﻿using System.Collections;
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
    public float itemDropRate = 5f;
    public GameObject item;

    public virtual void Awake ()
    {
        anim = GetComponent<Animator>();
    }

	public virtual void Start ()
    {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		shootPoint = GetComponentInChildren<Transform>();
        curHealth = maxHealth;

		Data.totalEnemyPower += (maxHealth + damage);
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
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

        if (curHealth <= 0)
        {   
            float rnd = Random.Range(0.000f, 100.000f);
            if (rnd < itemDropRate) {
                GameObject clonedItem =  Instantiate(item, transform.position, transform.rotation);
                clonedItem.GetComponent<ItemHealth>().healthRestored = Random.Range(10, 25);
            }
            Destroy(gameObject);
            Die();
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
        if (awake) {
            curHealth -= damage;
            GetComponent<Animation>().Play("Player_Damaged");
        }
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

    public virtual void Die()
    {
		Data.score += (maxHealth + damage);
    }
}
