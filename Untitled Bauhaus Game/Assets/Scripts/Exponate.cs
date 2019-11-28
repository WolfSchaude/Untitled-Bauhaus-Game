using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exponate : MonoBehaviour
{
    public Slider expoSlider;
    public Text expoText;

    int exponatCreateTimer = -1000;
    //private int dayCounter = 3; //Intervall in Tagen, wie oft ein Exponat hergestellt werden soll.
    private int textCooldown = 200;

    private bool exponatInProgress;
    private bool isExponatDone = false;
    void Start()
    {
        expoSlider.minValue = exponatCreateTimer;
    }

    void Update()
    {
        expoSlider.value = exponatCreateTimer; //set slider value to int value

        createExponat();

		//Debug.Log(dayCounter);

		//if (Random.Range(0, 2000) == 5 && !exponatInProgress) //Random Herstellung
		//{
		//    expoText.text = "Wird hergestellt...";
		//    exponatInProgress = true;
		//}
	}

    public void checkForButtonPress() //Herstellung mit Button
    {
		if (exponatCreateTimer == expoSlider.minValue)
		{
			expoText.text = "Exponat herstellen...";
			GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(7500);
			exponatInProgress = true;
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
            exponatCreateTimer++;
            if (exponatCreateTimer >= 0)
            {
                expoText.text = "Exponat hergestellt!";

                //int randomExponat = Random.Range(1, 3); //random number between 1 and 2
                //switch (randomExponat) //switch for different types of exhibits
                //{
                //    case 1:
                        Debug.Log("+rep");
                        GameObject.Find("AnsehenCounter").GetComponent<SliderValueToText>().sliderUI.value++; //Ansehen +
                        GameObject.Find("Money Display").GetComponent<Money>().Spende(Random.Range(5000, 25001));
                //        break;
                //    case 2:
                //        Debug.Log("-rep");
                //        GameObject.Find("AnsehenCounter").GetComponent<SliderValueToText>().sliderUI.value--; //Ansehen -
                //        break;
                //    default:
                //        Debug.Log("default case");
                //        break;
                //}

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
				exponatCreateTimer -= 2;
			}
			if(exponatCreateTimer == expoSlider.minValue)
			{
				isExponatDone = false;
			}

            if (textCooldown <= 0)
            {
                expoText.text = "Exponat-Herstellung";
                textCooldown = 200;
                
            }
        }
    }
}
