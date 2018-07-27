using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponIcon : MonoBehaviour {

	public GameObject[] Weapons;
	public GameObject CurrentWeapon;
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
	        CurrentWeapon.SetActive(true);
	    }
    }
}