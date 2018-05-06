using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TahuStatic : EnemyStatic {

	public GameObject soundManager;
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

        if (curHealth <= 0)
        {   
            soundManager.GetComponents<AudioSource>()[0].Play();
            float rnd = Random.Range(0.000f, 100.000f);
            if (rnd < itemDropRate) {
                GameObject clonedItem =  Instantiate(item, transform.position, transform.rotation);
                clonedItem.GetComponent<ItemHealth>().healthRestored = Random.Range(10, 50);
            }

			Die();
            Destroy(gameObject);
        }
    }

	public override void Attack() 
	{
		base.Attack();
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
