using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoodleBoss3 : Boss
{
    private Rigidbody2D rb;
    public float speed;
    public float maxSpeed;
    public float minSpeed;
    public GameObject noodleAttack;
    public float spawnTime;
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
        if (curHealth <= 0)
        {
            //Application.LoadLevel(0);
            attack = false;
            player.win = true;
            Destroy(gameObject);
            Die();
        } else if (curHealth <0.3*maxHealth)
        {
            spawnTime -= 1.5f;
        }
        else if (curHealth >= 0.9 * maxHealth)
        {

        }
        else if (curHealth < 0.9 * maxHealth)
        {
            attack = true;
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
            Vector3 noodlePosition;
            Vector2 direction = new Vector2(0, -1);
            GameObject noodleClone;
            noodlePosition = new Vector3(960.0f, 4.6f, 0);
            noodleClone = Instantiate(noodleAttack, noodlePosition, transform.rotation);
        }

        //yield return new WaitForSeconds(Random.Range(spawnLeastWait, spawnMostWait));
    }
}
