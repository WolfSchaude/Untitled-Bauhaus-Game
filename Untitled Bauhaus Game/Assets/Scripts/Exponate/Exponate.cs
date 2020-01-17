using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Exponate : MonoBehaviour
{
	public GameObject FeedbackTicker;
    public GameObject Playervariables;
    public FastForward TimeMode;
    public GameObject StartOrderButton;

    [SerializeField] Button JaAbbrechen;
    [SerializeField] Button NeinNichtAbbrechen;

    public UnityEvent exponatDone;
    public Slider expoSlider;
    public Text expoText;

    int exponatCreateTimer = -5000;
    //private int dayCounter = 3; //Intervall in Tagen, wie oft ein Exponat hergestellt werden soll.
    private int textCooldown = 200;
    private int expoPrice = 7500; //Herstellungspreis

    private bool exponatInProgress;
    public static bool isExponatDone = false;
    void Start()
    {
        expoText.text = "Exponat-Herstellung\n" + expoPrice + " RM";
        expoSlider.minValue = exponatCreateTimer;
    }

    void Update()
    {
		expoSlider.value = exponatCreateTimer; //set slider value to int value

        createExponat();

		//if (TimeMode.Mode == FastForward.TimeMode.FastForward)
		//{
		//	expoSlider.maxValue = -2000;
		//}
		//else if (TimeMode.Mode == FastForward.TimeMode.Normal)
		//{
		//	expoSlider.maxValue = 0;
		//}
	}

    public void checkForButtonPress() //Herstellung mit Button
    {
        if (exponatInProgress)
        {
            TryToCancel();
        }
        else
        {
            if (Playervariables.GetComponent<Money>().money > expoPrice) //Exponate können nur hergestellt werden, wenn man das benötigte Geld dafür hat.
            {
                if (exponatCreateTimer == expoSlider.minValue)
                {
                    expoText.text = "Wird hergestellt...\n -Klicken zum abbrechen-";
                    Playervariables.GetComponent<Money>().Bezahlen(expoPrice);
                    exponatInProgress = true;
                }
            }
        }
    }

    public void createExponat()
    {
        if (exponatInProgress && (TimeMode.Mode == FastForward.TimeMode.Normal || TimeMode.Mode == FastForward.TimeMode.FastForward))
        {
            switch (TimeMode.Mode)
            {
                case FastForward.TimeMode.Pause:
                    break;
                case FastForward.TimeMode.Normal:
                    exponatCreateTimer += (GameObject.Find("EventSystem").GetComponent<bewerbungvisible>().zugewiesenenCounter);
                    break;
                case FastForward.TimeMode.FastForward:
                    exponatCreateTimer += (GameObject.Find("EventSystem").GetComponent<bewerbungvisible>().zugewiesenenCounter * 4);
                    break;
                default:
                    break;
            }

			if (exponatCreateTimer >= expoSlider.maxValue)
            {
                expoText.text = "Exponat hergestellt!";

				FeedbackTicker.GetComponent<FeedbackScript>().NewTick("Ein Exponat wurde dem Inventar hinzugefügt.");

				exponatDone.Invoke();
                isExponatDone = true;
                exponatInProgress = false;
            }
        }

        if (isExponatDone && !exponatInProgress) //set text to default after time is up.
        {
            textCooldown--;

			if (exponatCreateTimer != expoSlider.minValue)
			{
				if (TimeMode.Mode == FastForward.TimeMode.Normal)
				{
					exponatCreateTimer -= 2;
				}
				else if (TimeMode.Mode == FastForward.TimeMode.FastForward)
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

    public void TryToCancel()
    {
        JaAbbrechen.gameObject.SetActive(true);
        NeinNichtAbbrechen.gameObject.SetActive(true);

        StartOrderButton.transform.localScale = Vector3.zero;
    }

    public void DontCancel()
    {
        JaAbbrechen.gameObject.SetActive(false);
        NeinNichtAbbrechen.gameObject.SetActive(false);

        StartOrderButton.transform.localScale = Vector3.one;
    }

    public void YesPleaseCancel()
    {
        cancelExponat();

        JaAbbrechen.gameObject.SetActive(false);
        NeinNichtAbbrechen.gameObject.SetActive(false);

        StartOrderButton.transform.localScale = Vector3.one;
    }

    public void cancelExponat()
    {
        if (exponatInProgress && !isExponatDone /*&& exponatCreateTimer >= -4970*/)
        {
            exponatInProgress = false;
            isExponatDone = false;
            exponatCreateTimer = -5000;
            FeedbackTicker.GetComponent<FeedbackScript>().NewTick("Exponat-Herstellung abgebrochen.");
            expoText.text = "Exponat-Herstellung\n" + expoPrice + " RM";
        }
    }
}
