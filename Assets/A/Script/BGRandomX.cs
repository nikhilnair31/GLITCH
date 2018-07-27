using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGRandomX : MonoBehaviour {

	public GameObject[] Images;
	public GameObject CurrentImage1;
	public float time;
	private int x;

	void Start () 
	{
		CurrentImage1 = Images[0];
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
		CurrentImage1 = Images[x];
	    CurrentImage1.SetActive(true);
    }
}