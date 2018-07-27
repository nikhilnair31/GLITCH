using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public Transform player;
	private Rigidbody2D rb2D;
	private Animator myAnimator;
	public LayerMask walls;
	private Vector2 movement;
	private float timeLeft;
	public int accelerationTime;
	public float y,coneAngle,minDist,timeDelay,amt,speed,maxSpeed = 5f;
	bool isCoroutineStarted = false;

	void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
		myAnimator = GetComponent<Animator>();
		accelerationTime = Random.Range(1, 7);
    }

	void FixedUpdate()
    {
		float distance = Vector2.Distance(player.transform.position, transform.position);

		Vector3 targetDir = player.transform.position - transform.position;
        float angle = Vector3.Angle(targetDir, transform.up);
        timeLeft -= Time.deltaTime;
 
        if ((angle <= coneAngle) && (distance <= minDist))
        {
			float z = Mathf.Atan2((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;
            transform.eulerAngles = new Vector3(0,0,z);
		    rb2D.AddForce(gameObject.transform.up*speed);
			if(!isCoroutineStarted)
            {
              StartCoroutine(Delay());
            }
		}	
		else if(timeLeft <= 0)
		{
		    rb2D.AddForce(movement * maxSpeed);
			rb2D.MoveRotation(Random.Range(-amt, amt));
		}
			
    }

	void Update()
    {
        if(timeLeft <= 0)
        {
          movement = new Vector2(Random.Range(-amt, amt), Random.Range(-amt, amt));
          timeLeft += accelerationTime;
        }
    }

	IEnumerator Delay() 
    {
		isCoroutineStarted = true;
        yield return new WaitForSeconds(timeDelay);
        myAnimator.SetTrigger("BAttack");
		isCoroutineStarted = false;
    }

}