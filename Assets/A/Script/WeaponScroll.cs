using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScroll : MonoBehaviour {

	public GameObject[] Weapons;
	public GameObject CurrentWeapon;
	public Animator myAnimator;
	public int WeaponNumber;
	private float x;

	void Start () 
	{
		CurrentWeapon = Weapons[0];
	}
	
	void Update () 
	{
	  x = Input.GetAxis("Mouse ScrollWheel");

       if(x!=0)
	   {
		   if(x > 0)
			{
               if(WeaponNumber >= 1)
			   {
                 WeaponNumber = 0;
			     CurrentWeapon.SetActive(false);
			   }
			   else
			   {
                 WeaponNumber = WeaponNumber + 1;
			     CurrentWeapon.SetActive(false);
			   }
			}
			else if(x < 0)
			{
               if(WeaponNumber <= 0)
			   {
                 WeaponNumber = 1;
			     CurrentWeapon.SetActive(false);
			   }
			   else
			   {
                 WeaponNumber = WeaponNumber - 1;
			     CurrentWeapon.SetActive(false);
			   }
			}
		    CurrentWeapon = Weapons[WeaponNumber];
	        
			if(WeaponNumber==0)
			{
				CurrentWeapon.SetActive(false);
			}
			else
			{
				CurrentWeapon.SetActive(true);;
			}

			if(WeaponNumber==1)
			{
				myAnimator.SetBool("Bow",false);
				myAnimator.SetBool("Defend",true);
			}
			else if(WeaponNumber==2)
			{
				myAnimator.SetBool("Defend",false);
				myAnimator.SetBool("Bow",true);
			}
	    }

    }
}