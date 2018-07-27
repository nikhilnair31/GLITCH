using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuu : MonoBehaviour {

	public static bool GameIsPaused = true;
	public GameObject pauseMenuUI;
	//public Animator myAnimator;

	void Start ()
    {
		//myAnimator = GetComponent<Animator>();
    }
	
	void Update () {

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(GameIsPaused)
			{
				Resume();
			}
			else
			{
				Pause();
			}
		}
	}

	public void Pause()
	{
		GameIsPaused = true;
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		//pauseMenuUI.GetComponent<Animator>().SetTrigger("Pause");
	}

	public void Resume()
	{
		GameIsPaused = false;
		pauseMenuUI.SetActive(false);
		//pauseMenuUI.GetComponent<Animator>().SetTrigger("Resume");
		Time.timeScale = 1f;
		//StartCoroutine(Delay());	
    }

	IEnumerator Delay()
	{
		yield return new WaitForSeconds(2f);
		pauseMenuUI.SetActive(false);
	}

}
