using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Studenten : MonoBehaviour, ISaveableInterface
{

    public int studKapazitaet = 500; //Anfangskapazität

    public int StudentenAnzahl = 50;
    private int monthlyStudenten = 50;
    private float sliderPercentage;

    public Text studDisplay;

    public GameObject SaveGameKeeper;
    public GameObject FeedbackTicker;

    void Start()
    {
		//InvokeRepeating("addStudenten", 0.1f, 2.0f); //repeats a function every x seconds
		StudentenAnzahl = 50;
    }

    void Update()
    {
		if (StudentenAnzahl < 0)
		{
			StudentenAnzahl = 0;
		}

        studDisplay.text = "Studenten: " + StudentenAnzahl.ToString("0") + " / " + studKapazitaet.ToString(); //Display StudentenAnzahl in UI
    }

    public void addStudenten()
    {
        monthlyStudenten = Mathf.RoundToInt(5f * Mathf.Sqrt(gameObject.GetComponent<AnsehenScript>().Ansehen * Mathf.PI)) * 5;

		FeedbackTicker.GetComponent<FeedbackScript>().NewTick(monthlyStudenten + " Studenten sind der Hochschule beigetreten.");

		StudentenAnzahl += monthlyStudenten;

		if (StudentenAnzahl >= studKapazitaet)
		{
			StudentenAnzahl = studKapazitaet;
		}
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
}
