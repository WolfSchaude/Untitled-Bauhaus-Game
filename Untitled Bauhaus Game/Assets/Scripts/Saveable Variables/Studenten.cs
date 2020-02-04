using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Studenten : MonoBehaviour, ISaveableInterface
{

	public int studKapazitaet = 500; //Anfangskapazität

	public int StudentenAnzahl = 50;
	public int monthlyStudenten { get; private set; } = 50;

	public Text studDisplay;

	public GameObject SaveGameKeeper;

	void Start()
	{
		//Start replaced by LoadStart triggered by SaveGameManager
	}

	void Update()
	{
		if (StudentenAnzahl < 0)
		{
			StudentenAnzahl = 0;
		}

		studDisplay.text = StudentenAnzahl.ToString("0") + " / " + studKapazitaet.ToString(); //Display StudentenAnzahl in UI
	}

	public void addStudenten()
	{
		if (StudentenAnzahl < studKapazitaet)
		{
			monthlyStudenten = Mathf.RoundToInt(5f * Mathf.Sqrt(gameObject.GetComponent<AnsehenScript>().Ansehen * Mathf.PI)) * 5;
			if (StudentenAnzahl + monthlyStudenten >= studKapazitaet)
			{
				if (studKapazitaet - StudentenAnzahl == 1)
				{
					Ticker.NewTick.Invoke(studKapazitaet - StudentenAnzahl + " Student ist der Hochschule beigetreten.");
				}
				else
				{
					Ticker.NewTick.Invoke(studKapazitaet - StudentenAnzahl + " Studenten sind der Hochschule beigetreten.");
				}
			}
			else
			{
				Ticker.NewTick.Invoke(monthlyStudenten + " Studenten sind der Hochschule beigetreten.");
			}

			StudentenAnzahl += monthlyStudenten;

			if (StudentenAnzahl >= studKapazitaet)
			{
				StudentenAnzahl = studKapazitaet;
			}
		}
		else
		{
			monthlyStudenten = 0;
		}
    }

    public void MehrKapazitaet(int Kapazität)
    {
        studKapazitaet += Kapazität;
    }

    public void Save()
    {
        SaveGameKeeper.GetComponent<SaveGameManager>().Savestate.StudentenAnzahl = StudentenAnzahl;
        SaveGameKeeper.GetComponent<SaveGameManager>().Savestate.MaxStudenten = studKapazitaet;
        SaveGameKeeper.GetComponent<SaveGameManager>().WhoHasSaved[4] = true;
    }
    public void Load(Save save)
    {
        StudentenAnzahl = save.StudentenAnzahl;
        studKapazitaet = save.MaxStudenten;
    }

	public void LoadStart()
	{
		StudentenAnzahl = 50;
	}
}
