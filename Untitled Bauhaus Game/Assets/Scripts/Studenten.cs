using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Studenten : MonoBehaviour
{

    public float StudentenAnzahl = 50;
    private float monthlyStudenten = 50;
    private float sliderPercentage;

    public Text studDisplay;
    

    void Start()
    {
		//InvokeRepeating("addStudenten", 0.1f, 2.0f); //repeats a function every x seconds
		StudentenAnzahl = 50;
    }

    void Update()
    {
        studDisplay.text = "Studenten: " + StudentenAnzahl.ToString("0") + " / " + GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität.ToString(); //Display StudentenAnzahl in UI
    }

    public void addStudenten()
    {
		sliderPercentage = ((GameObject.Find("AnsehenCounter").GetComponent<SliderValueToText>().sliderUI.value / GameObject.Find("AnsehenCounter").GetComponent<SliderValueToText>().sliderUI.maxValue) * 100);

		monthlyStudenten = 5f * sliderPercentage;

		StudentenAnzahl += monthlyStudenten;

		if (StudentenAnzahl >= GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität)
		{
			StudentenAnzahl = GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität;
		}
    }
}
