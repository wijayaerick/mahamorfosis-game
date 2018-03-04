using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float maxSpeed = 3f;
    public float speed = 50f;
    public float jumpPower = 250f;
    public bool grounded;
    public bool canDoubleJump;
    public int curHealth = 5;

    private float inputAxisHorizontal;
    private Rigidbody2D rb;
    private Animator anim;

    void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
	}
	
	void Update ()
    {
        anim.SetBool("grounded", grounded);
        anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));
        if (inputAxisHorizontal < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (inputAxisHorizontal > 0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                rb.AddForce(Vector2.up * jumpPower);
            }
            else if (canDoubleJump)
            {
                canDoubleJump = false;
                rb.angularVelocity = 0f;
                rb.velocity = new Vector2(rb.velocity.x, 0.0f);
                rb.AddForce(Vector2.up * jumpPower / 1.2f);
            }
        }
    }

    void FixedUpdate()
    {
        Vector3 easeVelocity = rb.velocity;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 0.75f;


        inputAxisHorizontal = Input.GetAxis("Horizontal");

        // Friction and set double jump
        if (grounded)
        {
            rb.velocity = easeVelocity;
            canDoubleJump = true;
        }

        // Moving
        rb.AddForce(Vector2.right * speed * inputAxisHorizontal);
        if (rb.velocity.x > maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }
        if (rb.velocity.x < -maxSpeed)
        {
            rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
        }
    }

    public void Damage(int dmg)
    {
        gameObject.GetComponent<Animation>().Play("Player_Damaged");
        if (dmg > curHealth)
        {
            Die();
        }
        else
        {
            curHealth -= dmg;
        }
    }

    public void Die()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public IEnumerator Knockback(float knockDur, Vector2 knockDir)
    {
        float timer = 0f;

        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        while (knockDur > timer)
        {
            timer += Time.deltaTime;
            rb.AddForce(new Vector3(transform.position.x * knockDir.x, transform.position.y * knockDir.y, transform.position.z));
        }
        yield return 0;
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.CompareTag("Coin"))
        {
            Destroy(col.gameObject);
        }
    }


}
