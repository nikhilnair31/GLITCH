using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

	public Transform player;
	private Rigidbody2D rb2D;
	private Animator myAnimator;
	public GameObject bullet,bulletInst;
	public int count;
	public float y,swordScool,swordLcool,bulletCool,minRange,maxRange,limit,speed;
	public bool isCoroutineStarted,entered;
	
	void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
		myAnimator = GetComponent<Animator>();
		count = 0;
		isCoroutineStarted = false;
    }

	void FixedUpdate()
    {

		float z = Mathf.Atan2((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;
        transform.eulerAngles = new Vector3(0,0,z);
		rb2D.AddForce(gameObject.transform.up*speed);
		if(!isCoroutineStarted)
        {
            StartCoroutine(Attack());
        }	
			
    }

	IEnumerator Attack() 
    {
		isCoroutineStarted = true;
		count++;
        if(count>=4)
		{
			myAnimator.SetTrigger("BSwordL");
			//rb2D.velocity = new Vector2(0,0);
			//rb2D.AddForce(gameObject.transform.up*(-speed));
			yield return new WaitForSeconds(swordLcool);
			myAnimator.ResetTrigger("BSwordL");
			count = 0;
		}
		else if( (Random.Range(minRange,maxRange)) >= limit )
		{
			myAnimator.SetTrigger("BShoot");
			yield return new WaitForSeconds(bulletCool);
			bulletInst = Instantiate(bullet, transform.position, transform.rotation);
		    Destroy(bulletInst, 7f);
		}
		else
		{
			yield return new WaitForSeconds(swordScool);
			myAnimator.SetTrigger("BSwordS");
		}
		isCoroutineStarted = false;
    }

}