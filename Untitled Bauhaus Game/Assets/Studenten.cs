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
        //StudentenAnzahl += (GameObject.Find("AnsehenCounter").GetComponent<SliderValueToText>().sliderUI.value * monthlyStudenten) / 2;

        //    if (GameObject.Find("AnsehenCounter").GetComponent<SliderValueToText>().sliderUI.value <= 4 && GameObject.Find("AnsehenCounter").GetComponent<SliderValueToText>().sliderUI.value > 0) //Access sliderUI.value from another script
        //    {
        //        monthlyStudenten = 2;
        //    }
        //    if (GameObject.Find("AnsehenCounter").GetComponent<SliderValueToText>().sliderUI.value <= 7 && GameObject.Find("AnsehenCounter").GetComponent<SliderValueToText>().sliderUI.value > 4) 
        //    {
        //        monthlyStudenten = 5;
        //    }
        //    if (GameObject.Find("AnsehenCounter").GetComponent<SliderValueToText>().sliderUI.value <= 10 && GameObject.Find("AnsehenCounter").GetComponent<SliderValueToText>().sliderUI.value > 7)
        //    {
        //        monthlyStudenten = 10;
        //    }

        //if (((GameObject.Find("AnsehenCounter").GetComponent<SliderValueToText>().sliderUI.value / GameObject.Find("AnsehenCounter").GetComponent<SliderValueToText>().sliderUI.maxValue) * 100) <= 50)
        //{
        //    monthlyStudenten = 5;
        //}
        //else
        //{
        //    monthlyStudenten = 10;
        //}

        // StudentenAnzahl += monthlyStudenten;


    }
}
