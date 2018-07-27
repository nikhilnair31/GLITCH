using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArrival : MonoBehaviour {

	public ScoreManager playerScore;
	public GameObject Player,bossIntroExplosion,Boss,Module,Module1,Module2,Module3,Floor,newBox,Glass,Enemies,Doors;
	public int scoreLimit;
	private bool intro;

	void Start () {
		playerScore.GetComponent<ScoreManager>();
		intro = true;
	}

	void Update () {
		if(playerScore.score >= scoreLimit)
		{
		   if(intro)
			{
				BossIntro();
				Enemies.SetActive(false);
		        Glass.SetActive(false);
				Doors.SetActive(false);
                Module.SetActive(false);
		        Module1.SetActive(false);
		        Module2.SetActive(false);
		        Module3.SetActive(false);
		        Floor.SetActive(false);
		        newBox.SetActive(true);
		        Boss.SetActive(true);
				intro = false;
			}
		}
	}

	void BossIntro()
    {
		Player.transform.position = new Vector2(-17,17);
        GameObject objInst = Instantiate(bossIntroExplosion, Player.transform.position, transform.rotation);
		Destroy(objInst, 2f);
    }
}
