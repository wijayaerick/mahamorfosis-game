using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float maxDistance = 12f;
    private float distanceTravelled = 0f;
    private Vector2 lastPosition;

    // Use this for initialization
    void Start()
    {
        lastPosition = transform.position;
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

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.isTrigger)
        {
            if (col.CompareTag("Enemy"))
            {
                col.GetComponentInParent<TurretController>().Damage(20);
            }
            Destroy(gameObject);
        }
    }
}
