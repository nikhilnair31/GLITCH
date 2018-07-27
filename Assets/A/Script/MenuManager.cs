using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public PauseMenuu pauseMenuUI;
	public Player player;

	void Start () {
		player.GetComponent<Player>();
	}

	public void toResume()
	{
		Time.timeScale = 1.0f;
		pauseMenuUI.Resume();
	}

	public void toRestart()
	{
		Time.timeScale = 1.0f;
		player.currentHealth=1f;
		SceneManager.LoadScene("L1");
	}

	public void toExit()
	 {
        Application.Quit();
	}

	/*public void toHow()
	 {
		 StartCoroutine(Delayy("how"));
	}
	
	public void toAbout()
	 {
		 StartCoroutine(Delayy("about"));
	}

	public void toMenu()
	 {
		 SceneManager.LoadScene("menu");
	}*/

	/*public void toReset()
	{
		PlayerPrefs.DeleteKey("HighScore");	
	}

	IEnumerator Delayy(string scene)
	{
		yield return new WaitForSeconds(0f);
		//pauseMenuUI.SetActive(false);
		SceneManager.LoadScene(scene);
	}*/

}
