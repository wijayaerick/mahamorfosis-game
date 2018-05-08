using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // Movement
    public float maxSpeed = 3f;
    private float currMaxSpeed;
    public float speed = 60f;
    public float jumpPower = 450f;
    public bool grounded;
    private bool canDoubleJump;
    private bool isMobile = false;
    
    // Health
    public int maxHealth;
    public int curHealth;

    // Shoot
    public int damage = 20;
    public int damageUlti = 25;
    public int ulti = 3;

    // Shoot Direction
    private bool lookingUp = false;
    private bool isDoubleJumping = false;
    public bool dead = false;
    public bool win = false;
    private bool duck = false;

    public float inputHorizontal;
    public float inputVertical;
    private Rigidbody2D rb;
    private Animator anim;
    private AudioSource audioJump;
    private bool lookingRight = true;

    void Start ()
    {
		#if UNITY_IOS
			isMobile = true;
		#elif UNITY_ANDROID
			isMobile = true;
		#elif UNITY_EDITOR
			isMobile = false;
		#else
			isMobile = false;
		#endif
        
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();

        audioJump = GetComponents<AudioSource>()[0];
        
        curHealth = maxHealth;

        anim.SetBool("dead", false);

        // fix position
        transform.position = new Vector3(transform.position.x + 1.6f, transform.position.y, transform.position.z);
	}
	
	void Update ()
    {
        // Update animator
        anim.SetBool("grounded", grounded);
        anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));
        anim.SetBool("lookingUp", lookingUp);
        anim.SetBool("doubleJump", isDoubleJumping);

        // Handle Player Orientation (Left/Right)
        if (!dead) {
            if (inputHorizontal < -0.1f && lookingRight)
            {
                lookingRight = false;
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                transform.position = new Vector3(transform.position.x - 1.6f, transform.position.y, transform.position.z);
            }
            if (inputHorizontal > 0.1f && !lookingRight)
            {
                lookingRight = true;
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                transform.position = new Vector3(transform.position.x + 1.6f, transform.position.y, transform.position.z);
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
                Jump();
            }
        }

        currMaxSpeed = maxSpeed;
        if (!grounded) {
            currMaxSpeed /= 2;
        }
    }

    void FixedUpdate()
    {
        // Fake Friction
        Vector3 easeVelocity = rb.velocity;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 0.75f;

        if (!isMobile) {
            inputHorizontal = Input.GetAxis("Horizontal");
            inputVertical = Input.GetAxis("Vertical");
        }

        // Friction and set double jump
        if (grounded)
        {
            rb.velocity = easeVelocity;
            canDoubleJump = true;
            isDoubleJumping = false;
        }

        // Moving
        if (!dead) {
            rb.AddForce(Vector2.right * speed * inputHorizontal);
            if (rb.velocity.x > currMaxSpeed)
            {
                rb.velocity = new Vector2(currMaxSpeed, rb.velocity.y);
            }
            if (rb.velocity.x < -currMaxSpeed)
            {
                rb.velocity = new Vector2(-currMaxSpeed, rb.velocity.y);
            }
        }
    }

    public void Damage(int dmg)
    {
        if (!win) {
            gameObject.GetComponent<Animation>().Play("Player_Damaged");
            if (dmg > curHealth)
            {
                curHealth = 0;
                Die();
            }
            else
            {
                curHealth -= dmg;
            }
        }
    }

    public void Die()
    {
        anim.SetBool("dead", true);
        dead = true;
        rb.velocity = Vector3.zero;
        //Application.LoadLevel(Application.loadedLevel);
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

            if (dead) {
                rb.velocity = Vector3.zero;
            } else {
                rb.AddForce(new Vector3(transform.position.x + knockDir.x, transform.position.y + knockDir.y, transform.position.z) / 3);
            }
        }
        yield return 0;
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        // if (col.CompareTag("Coin"))
        // {
        //     Destroy(col.gameObject);
        // }

    }

    public bool isLookingUp()
    {
        return lookingUp;
    }

    public bool isDucking()
    {
        return duck;
    }

    public void Jump()
    {
        if (grounded)
        {
            audioJump.Play();
            rb.AddForce(Vector2.up * jumpPower);
        }
        else if (canDoubleJump)
        {
            isDoubleJumping = true;
            audioJump.Play();
            canDoubleJump = false;
            rb.angularVelocity = 0f;
            rb.velocity = new Vector2(rb.velocity.x, 0.0f);
            rb.AddForce(Vector2.up * jumpPower / 1.15f);
        }
    }

    public void IncreaseHealth(int healthRestored) {
        curHealth += healthRestored;
        if (curHealth > maxHealth)
            curHealth = maxHealth;
    }
}
