using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Exponate : MonoBehaviour
{
	public GameObject FeedbackTicker;

	public UnityEvent exponatDone;
    public Slider expoSlider;
    public Text expoText;

    int exponatCreateTimer = -5000;
    //private int dayCounter = 3; //Intervall in Tagen, wie oft ein Exponat hergestellt werden soll.
    private int textCooldown = 200;
    private int expoPrice = 7500; //Herstellungspreis

    public bool exponatInProgress;
    public bool isExponatDone = false;
    void Start()
    {
        expoText.text = "Exponat-Herstellung\n" + expoPrice + " RM";
        expoSlider.minValue = exponatCreateTimer;
    }

    void Update()
    {
		expoSlider.value = exponatCreateTimer; //set slider value to int value

        createExponat();

		if (Time.timeScale == 3)
		{
			expoSlider.maxValue = -2000;
		}
		else if (Time.timeScale == 1)
		{
			expoSlider.maxValue = 0;
		}

		//Debug.Log(dayCounter);

		//if (Random.Range(0, 2000) == 5 && !exponatInProgress) //Random Herstellung
		//{
		//    expoText.text = "Wird hergestellt...";
		//    exponatInProgress = true;
		//}
	}

    public void checkForButtonPress() //Herstellung mit Button
    {
        if (GameObject.Find("Money Display").GetComponent<Money>().money > expoPrice) //Exponate können nur hergestellt werden, wenn man das benötigte Geld dafür hat.
        {
            if (exponatCreateTimer == expoSlider.minValue)
            {
                expoText.text = "Wird hergestellt...\n -Klicken zum abbrechen-";
                GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(expoPrice);
                exponatInProgress = true;
            }
        }
    }

    //public void countDays() //Herstellung im Intervall von x Tagen
    //{
    //    if (!exponatInProgress)
    //    {
    //        dayCounter--;

    //        if (dayCounter == 0)
    //        {
    //            expoText.text = "Wird hergestellt...";
    //            exponatInProgress = true;
    //            dayCounter = 3;
    //        }
    //    }
    //}
    public void createExponat()
    {
        if (exponatInProgress)
        {
			exponatCreateTimer += (GameObject.Find("EventSystem").GetComponent<bewerbungvisible>().zugewiesenenCounter);

			if (exponatCreateTimer >= expoSlider.maxValue)
            {
                expoText.text = "Exponat hergestellt!";

                //int randomExponat = Random.Range(1, 3); //random number between 1 and 2
                //switch (randomExponat) //switch for different types of exhibits
                //{
                //    case 1:
                        GameObject.Find("AnsehenCounter").GetComponent<SliderValueToText>().sliderUI.value++; //Ansehen +
						FeedbackTicker.GetComponent<FeedbackScript>().NewTick("Dein Exponat hat dein Ansehen um 1 verbessert.");
						var i = Random.Range(5000, 25001);
						GameObject.Find("Money Display").GetComponent<Money>().Spende(i);
						FeedbackTicker.GetComponent<FeedbackScript>().NewTick("Dein Exponat hat dir " + i + " RM eingebracht.");
				//        break;
				//    case 2:
				//        Debug.Log("-rep");
				//        GameObject.Find("AnsehenCounter").GetComponent<SliderValueToText>().sliderUI.value--; //Ansehen -
				//        break;
				//    default:
				//        Debug.Log("default case");
				//        break;
				//}
				exponatDone.Invoke();
                isExponatDone = true;
                exponatInProgress = false;
                //exponatCreateTimer = -1000;
            }
        }

        if (isExponatDone && !exponatInProgress) //set text to default after time is up.
        {
            textCooldown--;

			if (exponatCreateTimer != expoSlider.minValue)
			{
				if (Time.timeScale == 1)
				{
					exponatCreateTimer -= 2;
				}
				else if (Time.timeScale == 3)
				{
					exponatCreateTimer -= 6;
				}
			}
			if (exponatCreateTimer < expoSlider.minValue)
			{
				exponatCreateTimer = (int)expoSlider.minValue;
			}
			if (exponatCreateTimer == expoSlider.minValue)
			{
				isExponatDone = false;
			}

            if (textCooldown <= 0)
            {
                expoText.text = "Exponat-Herstellung\n" + expoPrice + " RM";
                textCooldown = 200;
                
            }
        }
    }

    public void cancelExponat()
    {
        if(exponatInProgress && !isExponatDone && exponatCreateTimer >= -4970)
        {
            exponatInProgress = false;
            isExponatDone = false;
            exponatCreateTimer = -5000;
            FeedbackTicker.GetComponent<FeedbackScript>().NewTick("Exponat-Herstellung abgebrochen.");
            expoText.text = "Exponat-Herstellung\n" + expoPrice + " RM";
        }
    }
}
