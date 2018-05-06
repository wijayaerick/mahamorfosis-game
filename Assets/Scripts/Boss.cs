using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Boss : MonoBehaviour
{

    public int curHealth;
    public int maxHealth;
    public int damage;
    protected Player player;
	protected Animator anim;


    public virtual void Awake()
    {
		anim = GetComponent<Animator>();
    }

    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        curHealth = maxHealth;
    }

    public virtual void Update()
    {

    }

    public void RangeCheck()
    {
     
    }

    public virtual void Attack()
    {
       
    }

    public virtual void Damage(int damage)
    {
        curHealth -= damage;
        //GetComponent<Animation>().Play("Player_Damaged");
    }

    public virtual void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            player.Damage(damage);


            if (player.transform.localScale.x > 0)
            {
                StartCoroutine(player.Knockback(0.02f, new Vector2(-200, 200)));
            }
            else
            {
                StartCoroutine(player.Knockback(0.02f, new Vector2(200, 200)));
            }
        }
    }

    public virtual void Die()
    {

    }
}
