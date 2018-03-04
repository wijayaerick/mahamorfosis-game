using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    private bool attacking = false;
    private float attackTimer = 0;
    private float attackCd = 0.3f;

    public GameObject bullet;
    public Transform shootPoint;
    public float bulletSpeed = 10f;

    private Animator anim;

	void Awake ()
    {
        anim = GetComponent<Animator>();
	}
	
	void Update ()
    {
		if (Input.GetKeyDown("x") && !attacking)
        {
            attacking = true;
            attackTimer = attackCd;
            Attack();
        }

        if (attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
            }
        }

        anim.SetBool("attacking", attacking);
	}

    public void Attack()
    {
         Vector2 direction = shootPoint.position - transform.position;
         direction.Normalize();

         GameObject bulletClone;
         bulletClone = Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation);
         bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
}
