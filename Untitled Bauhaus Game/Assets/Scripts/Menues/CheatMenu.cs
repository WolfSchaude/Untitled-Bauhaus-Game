using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheatMenu : MonoBehaviour
{
	public GameObject CheatMenuWindow;

	public GameObject Playervariables;

	public Toggle bauzeitToggle;
    void Start()
    {
        
    }

    void Update()
    {
		if (Input.GetKeyDown(KeyCode.F11))
		{
			print("Toggled Cheatmenu");
			CheatMenuWindow.SetActive(!CheatMenuWindow.activeSelf);
		}

		deactivateBuildTime();
    }

	public void deactivateBuildTime()
	{
		Playervariables.GetComponent<Bausystem>().CheatActive = bauzeitToggle.isOn;
	}

	public void AnsehenPlus()
	{
		Playervariables.GetComponent<AnsehenScript>().Ansehen++;
	}
	public void AnsehenMinus()
	{
		Playervariables.GetComponent<AnsehenScript>().Ansehen--;
	}

	public void StudentenPlus()
	{
		Playervariables.GetComponent<Studenten>().studKapazitaet += 100;
		Playervariables.GetComponent<Studenten>().StudentenAnzahl = Playervariables.GetComponent<Studenten>().studKapazitaet;
	}
	public void StudentenMinus()
	{
		Playervariables.GetComponent<Studenten>().StudentenAnzahl -= 100;
	}
	public void PolitikPlus()
	{
		Playervariables.GetComponent<Politikmeter>().ManipulatePolitics(10);
	}
	public void PolitikMinus()
	{
		Playervariables.GetComponent<Politikmeter>().ManipulatePolitics(-10);
	}

	public void cheatExponat()
	{
		GameObject.Find("ExponatSlider").GetComponent<Exponate>().exponatDone.Invoke();
	}

}
