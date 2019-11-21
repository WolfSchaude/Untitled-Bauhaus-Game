using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Studenten : MonoBehaviour
{

    public float StudentenAnzahl = 0;
    private float monthlyStudenten = 50;
    private float sliderPercentage;

    public Text studDisplay;
    

    void Start()
    {
        InvokeRepeating("addStudenten", 0.1f, 2.0f); //repeats a function every x seconds
    }

    void Update()
    {
        studDisplay.text = StudentenAnzahl.ToString("0"); //Display StudentenAnzahl in UI
    }

    public void addStudenten()
    {
        sliderPercentage = ((GameObject.Find("AnsehenCounter").GetComponent<SliderValueToText>().sliderUI.value / GameObject.Find("AnsehenCounter").GetComponent<SliderValueToText>().sliderUI.maxValue) * 100);

        monthlyStudenten = 5f * sliderPercentage;

        StudentenAnzahl += monthlyStudenten;
    }
}
