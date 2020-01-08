﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmallStudenten : MonoBehaviour
{

    public float StudentenAnzahl = 50;
    private float monthlyStudenten = 50;
    private float sliderPercentage;

    public Text studDisplay;


    void Start()
    {
        StudentenAnzahl = 50;
    }

    void Update()
    {
        if (StudentenAnzahl < 0)
        {
            StudentenAnzahl = 0;
        }

        studDisplay.text = StudentenAnzahl.ToString("0") + " / " + GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität.ToString(); //Display StudentenAnzahl in UI
    }

    public void addStudenten()
    {
        monthlyStudenten = Mathf.RoundToInt(5f * Mathf.Sqrt(GameObject.Find("AnsehenCounter").GetComponent<AnsehenScript>().Ansehen * Mathf.PI)) * 5;

        GameObject.Find("Button - Feedback Ticker").GetComponent<FeedbackScript>().NewTick(monthlyStudenten + " Studenten sind der Hochschule beigetreten.");

        StudentenAnzahl += monthlyStudenten;

        if (StudentenAnzahl >= GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität)
        {
            StudentenAnzahl = GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität;
        }
    }
}
