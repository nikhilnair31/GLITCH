using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {

	private Rigidbody2D rb2D;
	public GameObject burstEffect;
	public GameObject objInst;
	public Player player;
	public float speed,t,y;
	public bool damage,wall,shield,dead;

	void Start () {
		rb2D = GetComponent<Rigidbody2D>();
		player.GetComponent<Player>();
		Debug.Log("OG"+player.currentHealth);
        rb2D.AddForce(gameObject.transform.up*speed);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("init"+player.currentHealth);
		if(other.gameObject.layer == 14)//Walls
		{
			Debug.Log("wall");
			wall = true;
		}
		else if(other.gameObject.layer == 10)//Shield
		{
			Debug.Log("shield");
			shield = true;
		}
		else if((other.gameObject.layer == 11) && (player.currentHealth!=0f))//Player
		{
			Debug.Log("hit"+player.currentHealth);
			damage = true;
		}
		if(player.currentHealth<=0f)//Dead
		{
			Debug.Log("die");
			dead = true;
		}
	}
}
