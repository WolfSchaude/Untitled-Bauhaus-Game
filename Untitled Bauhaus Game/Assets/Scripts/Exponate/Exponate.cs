using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Exponate : MonoBehaviour
{
	public GameObject FeedbackTicker;
    public GameObject Playervariables;
    public GameObject StartOrderButton;

    NewTimeKeeper TimeIsImportant;

    [SerializeField] Button JaAbbrechen;
    [SerializeField] Button NeinNichtAbbrechen;

    public UnityEvent exponatDone;
    public Slider expoSlider;
    public Text expoText;

    int exponatCreateTimer = -5000;
    //private int dayCounter = 3; //Intervall in Tagen, wie oft ein Exponat hergestellt werden soll.
    private int textCooldown = 200;
    private readonly int expoPrice = 7500; //Herstellungspreis

    private bool exponatInProgress;
    public static bool isExponatDone = false;
    void Start()
    {
        TimeIsImportant = Playervariables.GetComponent<NewTimeKeeper>();

        expoText.text = "Exponat-Herstellung\n" + expoPrice + " RM";
        expoSlider.minValue = exponatCreateTimer;
    }

    void Update()
    {
		expoSlider.value = exponatCreateTimer; //set slider value to int value

        createExponat();
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
        if (exponatInProgress && (TimeIsImportant.Mode == NewTimeKeeper.TimeMode.Normal || TimeIsImportant.Mode == NewTimeKeeper.TimeMode.FastForward))
        {
            switch (TimeIsImportant.Mode)
            {
                case NewTimeKeeper.TimeMode.Pause:
                    break;
                case NewTimeKeeper.TimeMode.Normal:
                    exponatCreateTimer += (GameObject.Find("EventSystem").GetComponent<bewerbungvisible>().zugewiesenenCounter);
                    break;
                case NewTimeKeeper.TimeMode.FastForward:
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
				if (TimeIsImportant.Mode == NewTimeKeeper.TimeMode.Normal)
				{
					exponatCreateTimer -= 2;
				}
				else if (TimeIsImportant.Mode == NewTimeKeeper.TimeMode.FastForward)
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

	#region Methods needed to do the cancel and cancel-check for exponates
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
	#endregion
}
