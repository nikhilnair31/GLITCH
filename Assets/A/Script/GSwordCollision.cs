using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSwordCollision: MonoBehaviour {

    public EnemyHealth[] enemy;

	void Start () 
	{
        for(int i =0; i<3 ;i++)
        {
		  enemy[i].GetComponent<EnemyHealth>();
        }
	}

	void OnTriggerEnter2D(Collider2D other)
    {
       for(int i =0; i<3 ;i++)
       {
		  if(other.gameObject.layer == 8)
           {
              enemy[i].damaged = true;
           }
        }
    }
}