using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BSwordCollision: MonoBehaviour {
 
	public static bool damaged; 
	public Player player;
	public GameObject bloodEffect;
	public GameObject objInst;

	void Start () 
	{
		player.GetComponent<Player>();
	}

	void FixedUpdate()
	{
		if(damaged && (player.currentHealth!=0f))
        {
			player.currentHealth -= player.amount;
			player.healthSlider.value = player.currentHealth;
			objInst = Instantiate(bloodEffect, transform.position, transform.rotation);
		    Destroy(objInst, 2f);
			
        }
		else if(player.currentHealth==0f)
		{
			player.currentHealth=1f;
			SceneManager.LoadScene("Dead");
		}
		damaged = false;
	}

	void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.layer == 11)
        {
			damaged = true;
        }
    }
}