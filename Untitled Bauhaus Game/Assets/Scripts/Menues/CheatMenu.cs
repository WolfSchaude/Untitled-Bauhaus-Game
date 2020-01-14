using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UntitledBauhausGame;

public class CheatMenu : MonoBehaviour
{
	public GameObject CheatMenuWindow;

	public GameObject Playervariables;

	public Toggle bauzeitToggle;
	private bool bauzeitCheater = false;
    void Start()
    {
        
    }

    void Update()
    {
		showWindow();
		deactivateBuildTime();
    }

	public void showWindow()
	{
		if (Input.GetKeyDown(KeyCode.F11) && !CheatMenuWindow.activeSelf)
		{
			CheatMenuWindow.SetActive(true);
		}
		else if (Input.GetKeyDown(KeyCode.F11) && CheatMenuWindow.activeSelf)
		{
			CheatMenuWindow.SetActive(false);
		}
	}

	public void deactivateBuildTime()
	{
		if (bauzeitToggle.isOn)
		{
			GameObject.Find("UI").GetComponent<BaueArchitekturwerkstatt>().archBuildTimeInMonths = 0;
			GameObject.Find("UI").GetComponent<BaueMalerei>().malBuildTimeInMonths = 0;
			GameObject.Find("UI").GetComponent<BaueAusstellungsgestaltung>().ausBuildTimeInMonths = 0;
			GameObject.Find("UI").GetComponent<BaueMetallwerkstatt>().metallBuildTimeInMonths = 0;
			GameObject.Find("UI").GetComponent<BaueTischlerei>().tischBuildTimeInMonths = 0;
			GameObject.Find("UI").GetComponent<BaueLehrsaal>().lehrBuildTimeInMonths = 0;
			GameObject.Find("UI").GetComponent<BaueWohnheim>().wohnBuildTimeInMonths = 0;

			bauzeitCheater = true;
		}
		else
		{
			if (bauzeitCheater)
			{
				GameObject.Find("UI").GetComponent<BaueArchitekturwerkstatt>().archBuildTimeInMonths = 2;
				GameObject.Find("UI").GetComponent<BaueMalerei>().malBuildTimeInMonths = 2;
				GameObject.Find("UI").GetComponent<BaueAusstellungsgestaltung>().ausBuildTimeInMonths = 2;
				GameObject.Find("UI").GetComponent<BaueMetallwerkstatt>().metallBuildTimeInMonths = 2;
				GameObject.Find("UI").GetComponent<BaueTischlerei>().tischBuildTimeInMonths = 2;
				GameObject.Find("UI").GetComponent<BaueLehrsaal>().lehrBuildTimeInMonths = 2;
				GameObject.Find("UI").GetComponent<BaueWohnheim>().wohnBuildTimeInMonths = 2;
			}
			bauzeitCheater = false;
		}

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
		Playervariables.GetComponent<Politikmeter>().Politiklevel += 10;
	}
	public void PolitikMinus()
	{
		Playervariables.GetComponent<Politikmeter>().Politiklevel -= 10;
	}

	public void cheatExponat()
	{
		GameObject.Find("ExponatSlider").GetComponent<Exponate>().exponatDone.Invoke();
	}

}
