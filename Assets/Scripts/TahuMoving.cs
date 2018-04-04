﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TahuMoving : EnemyMoving {

	// Use this for initialization
	public GameObject soundManager;
	public bool isSmart;
	public override void Start ()
    {
		base.Start();
	}
	
	public override void Update ()
    {
        anim.SetBool("awake", awake);
		anim.SetBool("moving", awake);
        RangeCheck();

        if (awake)
        {
			if (isSmart) {
				if (player.transform.position.x < transform.position.x)
				{
					rb.AddForce(Vector2.right * speed * -1);
				} else
				{
					rb.AddForce(Vector2.right * speed * 1);
				}
			}
			else {
				rb.AddForce(Vector2.right * speed * -1);
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
            Destroy(gameObject);
            Die();
        }

    }
}