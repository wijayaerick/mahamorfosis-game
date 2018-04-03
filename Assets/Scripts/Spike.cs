using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour {

    public int damage = 40;
    public enum Direction {North, East, South, West};
    public Direction knockDir = Direction.North;

    private Player player;
    private Vector2 knockVector;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        switch (knockDir) {
            case Direction.North:
                knockVector = new Vector2(0, 300);
                break;
            case Direction.South:
                knockVector = new Vector2(0, -200);
                break;
            case Direction.West:
                knockVector = new Vector2(-150, 0);
                break;
            case Direction.East:
                knockVector = new Vector2(150, 0);
                break;    
            default:
                knockVector = new Vector2(0, 300);
                break;
        }
	}
	
	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Player")
        {
            player.Damage(damage);
            StartCoroutine(player.Knockback(0.02f, knockVector));
        }
	}
}
