using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Enemy : MonoBehaviour {

    public int curHealth;
    public int maxHealth = 60;
	public int damage = 1;

    public float distance = 0f;
    public float wakeRange = 5f;

    public bool awake = false;
	private Player player;

    public Animator anim;


    void Awake ()
    {
        anim = GetComponent<Animator>();
    }

	void Start ()
    {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        curHealth = maxHealth;
	}
	
	void Update ()
    {
        anim.SetBool("awake", awake);
        RangeCheck();

        if (curHealth <= 0)
        {
            Destroy(gameObject);
        }

	}

    void RangeCheck()
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

    abstract public void Attack();

    public virtual void Damage (int damage)
    {
        curHealth -= damage;
        GetComponent<Animation>().Play("Player_Damaged");
    }

    void OnColliderEnter2D(Collider2D col)
    {
		if (col.gameObject.tag == "Player")
		{
			player.Damage(damage);
			StartCoroutine(player.Knockback(0.02f, new Vector2(100, 100)));
		}
    }
}
