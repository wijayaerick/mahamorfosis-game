using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoodleBoss2 : Boss
{
    private Rigidbody2D rb;
    public float speed;
    public float maxSpeed;
    public float minSpeed;
    public GameObject msg;
    public float spawnTime;
    public float jumpPower = 450f;
    public bool grounded;
    public bool attack = false;
    // Use this for initialization
    public override void Awake()
    {
        base.Awake();
    }

    public override void Start()
    {
        base.Start();
        rb = gameObject.GetComponent<Rigidbody2D>();
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    public override void Update()
    {
        base.Update();
        if (curHealth < 0)
        {
            //Application.LoadLevel(0);
            attack = false;
            NoodleBoss.status = 1;
            Destroy(gameObject);
            Die();
        }
        else if (curHealth >= 0.9 * maxHealth)
        {
            if (grounded)
            {
                rb.AddForce(Vector2.up * jumpPower);
            }
        }
        else if (curHealth >= 0.7 * maxHealth && curHealth < 0.9 * maxHealth)
        {
            anim.SetBool("ready", true);
            anim.SetBool("attack", false);
        }
        else if (curHealth < 0.7 * maxHealth)
        {
            attack = true;
            anim.SetBool("ready", false);
            anim.SetBool("attack", true);
        }
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

    void Spawn()
    {
        if (attack)
        {
            Vector3 msgPosition;
            Vector2 direction = new Vector2(0, -1);
            for (int i = 0; i < 3; i++)
            {
                GameObject msgClone;
                float xPosition = Random.Range(-120.0f, 30);
                msgPosition = new Vector3(transform.localPosition.x + xPosition, transform.localPosition.y + 60, 0);
                msgClone = Instantiate(msg, msgPosition, transform.rotation);
                msgClone.GetComponent<Rigidbody2D>().velocity = direction * Random.Range(minSpeed, maxSpeed);
            }
        }
        
        //yield return new WaitForSeconds(Random.Range(spawnLeastWait, spawnMostWait));
    }
}
