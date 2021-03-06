﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinLose : MonoBehaviour
{
	public GameObject PlayerVariables;

	private Politikmeter politikmeterSkript;
	private Money moneySkript;
	private Studenten studentenSkript;

	public GameObject GameOverScreen;

	public Text GameOverText;

	private int PleiteThreshold = 30;
	private int PleiteCounter = 0;

	void Start()
    {
		politikmeterSkript = PlayerVariables.GetComponent<Politikmeter>();
		moneySkript = PlayerVariables.GetComponent<Money>();
		studentenSkript = PlayerVariables.GetComponent<Studenten>();
		GameOverScreen.SetActive(false);
	}

    void Update()
    {
		if (GameOverScreen.activeSelf)
		{
			Time.timeScale = 0;
			Kamera.LockCameraMovement.Invoke();
		}
        if(politikmeterSkript.Politiklevel >= 200)
		{
			//SceneManager.LoadScene("Main_Menu");
			//Debug.Log("Du bist zu weit rechts");
			GameOverScreen.SetActive(true);
			GameOverText.text = "Die Hochschule ist zu weit rechts";
		}
		if(politikmeterSkript.Politiklevel <= 0)
		{
		//	SceneManager.LoadScene("Main_Menu");
			//Debug.Log("Du bist zu weit links");
			GameOverScreen.SetActive(true);
			GameOverText.text = "Die Hochschule ist zu weit links";
		}
		if(PleiteCounter >= PleiteThreshold)
		{
			//SceneManager.LoadScene("Main_Menu");
			//Debug.Log("Sorry, bist pleite gegangen");
			GameOverScreen.SetActive(true);
			GameOverText.text = "Die Hochschule ist pleite gegangen";
		}
		if(studentenSkript.StudentenAnzahl <= 0)
		{
			//SceneManager.LoadScene("Main_Menu");
			//Debug.Log("Du hast keine Studenten mehr");
			GameOverScreen.SetActive(true);
			GameOverText.text = "Die Hochschule hat keine Studenten mehr.";
		}
    }

	public void IncreasePleiteCounter()
	{
		if (moneySkript.money < 0)
		{
			PleiteCounter++;
		}
		else
		{
			PleiteCounter = 0;
		}
	}

	public void GameOverThroughEvent(string announcement)
	{
		GameOverScreen.SetActive(true);
		GameOverText.text = announcement;
	}
}
