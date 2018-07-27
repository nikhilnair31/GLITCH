using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGRandom : MonoBehaviour {

	public GameObject[] Images;
	public GameObject CurrentImage1,CurrentImage2;
	public float time;
	private int x;

	void Start () 
	{
		CurrentImage1 = Images[0];
		CurrentImage2 = Images[1];
	}
	
	void Update () 
	{
	    StartCoroutine(Delay(time));
    }

	IEnumerator Delay(float delay) 
    {
        yield return new WaitForSeconds(time);
        x = Random.Range(0,5);
		CurrentImage1.SetActive(false);
		CurrentImage2.SetActive(false);
		CurrentImage1 = Images[x];
		CurrentImage2 = Images[x+1];
	    CurrentImage1.SetActive(true);
		CurrentImage2.SetActive(true);
    }
}