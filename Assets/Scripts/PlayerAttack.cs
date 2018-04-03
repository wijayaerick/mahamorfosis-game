using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public bool attacking = false;
    private float attackTimer = 0;
    public float attackCd = 0.7f;

    public GameObject bulletNormal;
    public GameObject bulletUlti;
    public Transform shootPointFront;
    public Transform shootPointUp;
    public Transform shootPointDuck;
    private Transform shootPoint;
    public float bulletSpeed = 10f;
    private bool isHorizontal;

    private Animator anim;
    private Player player;
    private AudioSource audioShoot;

	void Awake ()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
        audioShoot = GetComponents<AudioSource>()[1];
	}
	
	void Update ()
    {
		if (Input.GetButton("Shoot") && !attacking) // Use Input.GetButtonDown for single press (not hold)
        {
            Shoot();
        }

        if (Input.GetButton("Ulti") && !attacking)
        {
            Ulti();
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

    public void Shoot()
    {
        // Dua baris dibawah jangan diapus/dipindahin
        audioShoot.Play();
        attacking = true;
        attackTimer = attackCd;

        if (player.isLookingUp() && !player.isDucking())
        {
            shootPoint = shootPointUp;
            isHorizontal = false;
        } 
        else if (!player.isLookingUp() && player.isDucking())
        {
            shootPoint = shootPointDuck;
            isHorizontal = true;
        }
        else {
            shootPoint = shootPointFront;
            isHorizontal = true;
        }

        Vector2 direction = shootPoint.position - transform.position;
        if (isHorizontal)
        {
            direction.y = 0;
        }
        else {
            direction.x = 0;
        }
        direction.Normalize();

        GameObject bulletClone;
        bulletClone = Instantiate(bulletNormal, shootPoint.transform.position, shootPoint.transform.rotation);
        bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }

    public void Ulti()
    {
        // Dua baris dibawah jangan diapus/dipindahin
        attacking = true;
        attackTimer = attackCd;

        if (player.isLookingUp() && !player.isDucking())
        {
            shootPoint = shootPointUp;
            isHorizontal = false;
        } 
        else if (!player.isLookingUp() && player.isDucking())
        {
            shootPoint = shootPointDuck;
            isHorizontal = true;
        }
        else {
            shootPoint = shootPointFront;
            isHorizontal = true;
        }

        Vector2 direction = shootPoint.position - transform.position;
        if (isHorizontal)
        {
            direction.y = 0;
        }
        else {
            direction.x = 0;
        }
        direction.Normalize();

        GameObject bulletClone;
        bulletClone = Instantiate(bulletUlti, shootPoint.transform.position, shootPoint.transform.rotation);
        bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
}
