using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // Movement
    public float maxSpeed = 3f;
    public float speed = 60f;
    public float jumpPower = 380f;
    public bool grounded;
    private bool canDoubleJump;
    
    // Health
    public int maxHealth = 5;
    public int curHealth;

    // Shoot
    public int damage = 20;
    public int damageUlti = 120;
    public int maxUlti = 100;
    public int curUlti = 0;

    // Shoot Direction
    private bool lookingUp = false;
    private bool duck = false;

    private float inputHorizontal;
    private float inputVertical;
    private Rigidbody2D rb;
    private Animator anim;

    void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        curHealth = maxHealth;
	}
	
	void Update ()
    {
        // Update animator
        anim.SetBool("grounded", grounded);
        anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));

        // Handle Player Orientation (Left/Right)
        if (inputHorizontal < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (inputHorizontal > 0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        // Handle Upper Shoot Direction and Duck
        if (inputVertical < -0.1f && grounded)
        {
            duck = true;
            lookingUp = false;
        }
        else if (inputVertical > 0.1f)
        {
            duck = false;
            lookingUp = true;
        }
        else
        {
            duck = false;
            lookingUp = false;
        }

        // Handle Jumping
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
                rb.AddForce(Vector2.up * jumpPower / 1.15f);
            }
        }
    }

    void FixedUpdate()
    {
        // Fake Friction
        Vector3 easeVelocity = rb.velocity;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 0.75f;

        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");

        // Friction and set double jump
        if (grounded)
        {
            rb.velocity = easeVelocity;
            canDoubleJump = true;
        }

        // Moving
        rb.AddForce(Vector2.right * speed * inputHorizontal);
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
            if (transform.position.x >= 0 && knockDir.x < 0)
            {
                knockDir.x *= -1;
            } else if (transform.position.x < 0)
            {
                knockDir.x *= -1;
            }

            if (transform.position.y >= 0 && knockDir.y < 0)
            {
                knockDir.y *= -1;
            }
            else if (transform.position.y < 0)
            {
                knockDir.y *= -1;
            }

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

    public bool isLookingUp()
    {
        return lookingUp;
    }

    public bool isDucking()
    {
        return duck;
    }


}
