using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float maxDistance = 50f;
    private float distanceTravelled = 0f;
    private Vector2 lastPosition;
    private Rigidbody2D rb;

    void Start ()
    {
        lastPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        distanceTravelled += Vector2.Distance(transform.position, lastPosition);
        lastPosition = transform.position;
        if (distanceTravelled > maxDistance)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void OnTriggerStay2D (Collider2D col)
    {
        if (col.CompareTag("Enemy") || col.CompareTag("Boss") || col.CompareTag("Bullet")){

        } else {
            if (!col.isTrigger)
            {
                if (col.CompareTag("Player"))
                {
                    col.GetComponent<Player>().Damage(1);
                    StartCoroutine(col.GetComponent<Player>().Knockback(0.02f, rb.velocity*10));
                }
                Destroy(gameObject);
            }
        }
	}
}
