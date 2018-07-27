using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShooterMovement : MonoBehaviour {

	public Transform player;
	private Rigidbody2D rb2D;
	public Bullet B;
	public Player P;
	private Vector2 movement;
	public GameObject bullet;
	public GameObject bulletInst;
	private float timeLeft;
	public int accelerationTime;
	public float y,coneAngle,minDist,timeDelay,amt,speed,maxSpeed = 5f,count=0,rate;
	bool isCoroutineStarted = false;

	void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
		B.GetComponent<Bullet>();
		P.GetComponent<Player>();
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
			if(count<=rate)
			{
			  if(!isCoroutineStarted)
              {
                StartCoroutine(Fire());
              }
			}
			else
			{
				distance = Vector2.Distance(player.transform.position, transform.position);
		        targetDir = player.transform.position - transform.position;
                angle = Vector3.Angle(targetDir, transform.up);
                timeLeft -= Time.deltaTime;
				rb2D.AddForce(movement * maxSpeed);
			    rb2D.MoveRotation(Random.Range(-amt, amt));
				z = Mathf.Atan2((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;
                transform.eulerAngles = new Vector3(0,0,z);
				count = 0;
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

	IEnumerator Fire() 
    {
		count++;
		isCoroutineStarted = true;
        yield return new WaitForSeconds(timeDelay);
        bulletInst = Instantiate(bullet, transform.position, transform.rotation);
		Destroy(bulletInst, 7f);
		isCoroutineStarted = false;
    }

}