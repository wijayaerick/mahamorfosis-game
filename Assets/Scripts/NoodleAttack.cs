using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoodleAttack : EnemyMoving
{
    private Collider2D myCollider;
    public override void Start()
    {
        base.Start();
        myCollider = GetComponent<PolygonCollider2D>();
    }

    public override void Update()
    {
        RangeCheck();
        
        anim.SetBool("stay", true);
        anim.SetBool("down", false);
 
        if (player.transform.position.x < transform.position.x)
        {
            rb.AddForce(Vector2.right * speed * -1);
            //Debug.Log("gerak kiri");
        }
        else
        {
            rb.AddForce(Vector2.right * speed * 1);
            //Debug.Log("gerak kanan");
        }

        if (rb.velocity.x > maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }
        if (rb.velocity.x < -maxSpeed)
        {
            rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
        }

        if (curHealth <= 0)
        {
            anim.SetBool("stay", false);
            anim.SetBool("down", true);
            Destroy(gameObject);
            Die();
        }

    }

    public override void Damage (int damage)
    {
        base.Damage(damage);
        
    }
}
