using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exponat_Memory : MonoBehaviour
{
	public float Qualitaet;
	public GameObject FeedbackTicker;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void checkSellButton()
	{
		//GameObject.Find("AnsehenCounter").GetComponent<SliderValueToText>().sliderUI.value++; //Ansehen +
		//if (GameObject.Find("AnsehenProgressBar").GetComponent<Slider>().value != 10)
		//{
		//	FeedbackTicker.GetComponent<FeedbackScript>().NewTick("Dein Exponat hat dein Ansehen um 1 verbessert.");
		//}

		GameObject.Find("AnsehenCounter").GetComponent<AnsehenScript>().ManipulateAnsehen(1); //Ansehen +
		FeedbackTicker.GetComponent<FeedbackScript>().NewTick("Dein Exponat hat dein Ansehen um 1 verbessert.");

		var i = 15000 * Qualitaet;
		GameObject.Find("Money Display").GetComponent<Money>().Spende(i);
		FeedbackTicker.GetComponent<FeedbackScript>().NewTick("Dein Exponat hat dir " + i.ToString("0") + " RM eingebracht.");
	}
}
