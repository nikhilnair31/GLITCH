using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {
    
	public float health = 1,currentHealth = 1,amount;
	public bool damaged = false; 
	public Slider healthSlider;
    public float speed,force;  
	public static bool roll = false;
    private Rigidbody2D rb2d;
	private Animator myAnimator;
	public GameObject Sword;
	public GameObject Shield;
	public GameObject Bow;
	public GameObject bloodEffect;
	public GameObject objInst;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
		myAnimator = GetComponent<Animator>();
		healthSlider.value = 1;
		currentHealth = health = 1f;
		damaged = false;
    }

    void FixedUpdate()
    {

        float Horizontal = Input.GetAxis ("Horizontal");
        float Vertical = Input.GetAxis ("Vertical");
		rb2d.velocity = new Vector2(Horizontal*speed, Vertical*speed);

		if (Input.GetMouseButtonDown(0))
		{
			myAnimator.SetTrigger("Attack");
		}
		else if (Input.GetMouseButtonUp(0))
		{
			myAnimator.SetTrigger("Attack");
			myAnimator.ResetTrigger("Attack");
		}

		if (Input.GetMouseButtonDown(1))
		{
			myAnimator.SetBool("Defend",true);
		}
		else if (Input.GetMouseButtonUp(1))
		{
			myAnimator.SetBool("Defend",false);
		}

		if (Input.GetMouseButtonUp(2))
		{
			roll = false;
		}
		if(roll == false)
		{
            if (Input.GetMouseButtonDown(2))
		    {
		       //myAnimator.SetTrigger("Roll");
			   rb2d.AddForce(transform.up * force);
			   roll = true;
		    }
		}

		/*if(Bow.activeSelf)
		{
			if(Input.GetMouseButtonDown(1))
			{
				myAnimator.SetBool("Bow",true);
			}
			else if(Input.GetMouseButtonUp(1))
			{
				myAnimator.SetBool("Bow",false);
			}
		}*/
		
    }
	
}