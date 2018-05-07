using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletUlti : MonoBehaviour
{
    private Player player;
    private Animator anim;
    private float timer;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        anim = GetComponent<Animator>();
        
    }

    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 3 && !anim.IsInTransition(0)) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        timer = 0;
        if (col.CompareTag("Enemy") || col.CompareTag("Boss"))
        {
            col.SendMessage("Damage", player.damageUlti);
        }
    }

    void OnTriggerStay2D (Collider2D col)
    {
        timer += Time.deltaTime;
        if (timer >= 0.1) {
            if (col.CompareTag("Enemy") || col.CompareTag("Boss"))
            {
                col.SendMessage("Damage", player.damageUlti);
            }
            timer = 0;
        }
    }
}
