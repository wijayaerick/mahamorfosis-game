using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatic : Enemy {

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
        base.Update();
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
