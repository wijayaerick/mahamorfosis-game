using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoodleBoss2 :Boss
{
    private Rigidbody2D rb;
    public float speed;
    public float maxSpeed;
    public float minSpeed;
    public GameObject msg;
    public float spawnLeastWait;
    public float spawnMostWait;
    public int startWait;
    // Use this for initialization
    public override void Awake()
    {
        base.Awake();
    }

    public override void Start()
    {
        base.Start();
        rb = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(waitSpawner());
    }

    public override void Update()
    {
        base.Update();
         
    }

    public override void Attack()
    {

    }

    public override void OnCollisionEnter2D(Collision2D col)
    {
        base.OnCollisionEnter2D(col);
    }

    public override void Die()
    {
        base.Die();
    }

    IEnumerator waitSpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(startWait);
            Vector3 msgPosition;
            Vector2 direction = new Vector2(0, -1);
            for (int i = 0; i < 3; i++)
            {
                GameObject msgClone;
                float xPosition = Random.Range(-15.0f, 0);
                msgPosition = new Vector3(transform.position.x+xPosition, transform.position.y + 5, 0);
                msgClone = Instantiate(msg, msgPosition, transform.rotation);
                msgClone.GetComponent<Rigidbody2D>().velocity = direction* Random.Range(minSpeed, maxSpeed);
            }
            yield return new WaitForSeconds(Random.Range(spawnLeastWait, spawnMostWait));
        }
    }
}
