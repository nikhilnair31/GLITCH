using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private Rigidbody2D rb2D;
	public GameObject burstEffect,bloodEffect;
	public GameObject objInst;
	public Player P;
	public float speed;
	public bool damage,shield,wall;

	void Start () {
		speed = Random.Range(speed, (speed+0.1f));
		rb2D = GetComponent<Rigidbody2D>();
		P.GetComponent<Player>();
		rb2D.AddForce(gameObject.transform.up*speed);
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.layer == 14)//Walls
		{
			wall = true;
			objInst = Instantiate(burstEffect, transform.position, transform.rotation);
			Destroy(objInst, 2f);
			//Destroy(gameObject);
		}
		else if(other.gameObject.layer == 10)//Shield
		{
			shield = true;
			objInst = Instantiate(burstEffect, transform.position, transform.rotation);
			Destroy(objInst, 2f);
			Destroy(gameObject);
		}
		else if(other.gameObject.layer == 11)//Player
		{
			damage = true;
			objInst = Instantiate(burstEffect, transform.position, transform.rotation);
			if(damage && (P.currentHealth>0))
		    {
                P.currentHealth -= P.amount;
		        P.healthSlider.value = P.currentHealth;
				objInst = Instantiate(bloodEffect, transform.position, transform.rotation);
		        Destroy(objInst, 2f);
			    damage = false;
	    	}
			Destroy(objInst, 2f);
			Destroy(gameObject);
		}
	}
}