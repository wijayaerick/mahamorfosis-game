using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour {

    private TurretController tc;
    private BossController bc;
    public bool isLeft = false;
    public bool isBoss = false;

    void Awake ()
    {
        if (isBoss)
        {
            bc = GetComponentInParent<BossController>();
        }
        else
        {
            tc = GetComponentInParent<TurretController>();
        }
    }

    void OnTriggerStay2D (Collider2D col)
    {
		if (col.CompareTag("Player"))
        {
            if (isBoss)
            {
                bc.Attack(!isLeft);
            }
            else
            {
                tc.Attack(!isLeft);
            }
        }
	}
	
}
