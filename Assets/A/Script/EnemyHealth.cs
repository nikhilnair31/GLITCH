using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

	public float health,currentHealth,amount,offsetY,y;
	public int scoreValue = 100;   
	public bool damaged; 
	private Vector2 playerScreen;
	public Slider healthSlider;
	public Quaternion initRot; 
	public GameObject barPos; 
	public GameObject bloodEffect;
	public GameObject objInst;
	public ScoreManager Score;

    void Start()
    {
		healthSlider.value = 1;
		currentHealth = health;
		initRot = healthSlider.transform.rotation;
		Score.GetComponent<ScoreManager>();
    }

    void FixedUpdate()
    {
		healthSlider.transform.rotation = initRot;
		barPos.transform.position = new Vector2(transform.position.x, transform.position.y + offsetY);

        if(damaged && (currentHealth!=0f))
        {
			currentHealth -= amount;
			healthSlider.value = currentHealth;
			ExplodeAst();
        }
		else if(currentHealth<=0f)
		{
			ExplodeAst();
			Score.score += scoreValue;
			Destroy(gameObject);

		}
		damaged = false;
    }

	void OnTriggerEnter2D(Collider2D other)
    {
		if(other.gameObject.layer == 9)
        {
            damaged = true;
        }
    }

	void ExplodeAst()
    {
        Vector3 offset = new Vector3(0.0f,y,0.0f);
        objInst = Instantiate(bloodEffect, transform.position - offset, transform.rotation);
		Destroy(objInst, 2f);
    }

}