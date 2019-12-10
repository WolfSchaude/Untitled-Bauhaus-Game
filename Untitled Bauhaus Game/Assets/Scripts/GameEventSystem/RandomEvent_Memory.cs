using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomEvent_Memory : MonoBehaviour
{
	public int Politik1 = 0;
	public int Politik2 = 0;
	public int Ansehen1 = 0;
	public int Ansehen2 = 0;
	public int Geld1 = 0;
	public int Geld2 = 0;

	public int Vorlauf = 90;

	public int TimerCounter = 0;

	public Text Timer;

	public RandomEvent Memory;

	public bool IsFinished = false;

	private bool SelectedOne = false;
	private bool SelectedOption1 = false;
	private bool SelectedOption2 = false;

	public GameObject FeedbackTicker;

	void Start()
    {
		Memory = new RandomEvent();
    }

    // Update is called once per frame
    void Update()
    {
		if (TimerCounter > Vorlauf)
		{
			this.gameObject.SetActive(false);
		}
		if (TimerCounter < 0)
		{
			if (SelectedOption1)
			{
				EventEffect1();
			}
			else
			{
				if (SelectedOption2)
				{
					EventEffect2();
				}
				else
				{
					TooLate();
				}
			}

			this.gameObject.SetActive(false);
		}

		Timer.text = "Noch " + TimerCounter.ToString() + " Tage";
	}

    public void SetMemory(RandomEvent rev)
    {
		Memory = rev;

		Politik1 = Memory.Option1_Politik;
		Politik2 = Memory.Option2_Politik;
		Ansehen1 = Memory.Option1_Ansehen;
		Ansehen2 = Memory.Option2_Ansehen;
		Geld1 = Memory.Option1_Geld;
		Geld2 = Memory.Option2_Geld;

		GameObject.Find("EventSystem").GetComponent<DatumRelatedEvents>().changedDay.AddListener(() => { DecreaseTimerCounter(); });

		TimerCounter = Random.Range(90, 180);

		Vorlauf = 90;

		if (TimerCounter > Vorlauf)
		{
			this.gameObject.SetActive(false);
		}
	}

	public void SelectOption1()
	{
		if (!SelectedOne)
		{
			SelectedOption1 = true;
			SelectedOne = true;
			gameObject.GetComponentsInChildren<Button>()[0].interactable = false;
			gameObject.GetComponentsInChildren<Button>()[0].Select();

			var colours = gameObject.GetComponentsInChildren<Button>()[0].colors;   //Highlight Button with selected Option with a different Color
			colours.disabledColor = new Color32(155, 0, 0, 255);
			gameObject.GetComponentsInChildren<Button>()[0].colors = colours;
		}
	}
	public void SelectOption2()
	{
		if (!SelectedOne)
		{
			SelectedOption2 = true;
			SelectedOne = true;
			gameObject.GetComponentsInChildren<Button>()[1].interactable = false;
			gameObject.GetComponentsInChildren<Button>()[1].Select();

			var colours = gameObject.GetComponentsInChildren<Button>()[1].colors;   //Highlight Button with selected Option with a different Color
			colours.disabledColor = new Color32(155, 0, 0, 255);
			gameObject.GetComponentsInChildren<Button>()[1].colors = colours;
		}
	}
	private void EventEffect1()
	{
		GameObject.Find("AnsehenCounter").GetComponent<SliderValueToText>().sliderUI.value += Ansehen1;
		GameObject.Find("Politikmeter").GetComponent<Politikmeter>().Politiklevel += Politik1;
		GameObject.Find("Money Display").GetComponent<Money>().Geld(Geld1);

		if (Ansehen1 > 0)
		{
			FeedbackTicker.GetComponent<FeedbackScript>().NewTick("Das Event hat dein Ansehen um " + Ansehen1 + " verbessert.");
		}
		else
		{
			FeedbackTicker.GetComponent<FeedbackScript>().NewTick("Das Event hat dein Ansehen um " + Ansehen1 + " verschlechtert.");
		}

		if (Politik1 > 0)
		{
			FeedbackTicker.GetComponent<FeedbackScript>().NewTick("Das Event hat deine politische Position des Bauhaus um " + Politik1 + " nach rechts verschoben.");
		}
		else
		{
			FeedbackTicker.GetComponent<FeedbackScript>().NewTick("Das Event hat deine politische Position des Bauhaus um " + Politik1 + " nach links verschoben.");
		}

		if (Geld1 > 0)
		{
			FeedbackTicker.GetComponent<FeedbackScript>().NewTick("Das Event hat dir " + Geld1 + " RM eingebracht.");
		}
		else
		{
			FeedbackTicker.GetComponent<FeedbackScript>().NewTick("Durch das Event hast du " + Geld1 * -1 + " RM verloren.");
		}


		IsFinished = true;
		this.gameObject.SetActive(false);
	}
	private void EventEffect2()
	{
		GameObject.Find("AnsehenCounter").GetComponent<SliderValueToText>().sliderUI.value += Ansehen2;
		GameObject.Find("Politikmeter").GetComponent<Politikmeter>().Politiklevel += Politik2;
		GameObject.Find("Money Display").GetComponent<Money>().Geld(Geld2);

		if (Ansehen2 > 0)
		{
			FeedbackTicker.GetComponent<FeedbackScript>().NewTick("Das Event hat dein Ansehen um " + Ansehen2 + " verbessert.");
		}
		else
		{
			FeedbackTicker.GetComponent<FeedbackScript>().NewTick("Das Event hat dein Ansehen um " + Ansehen2 + " verschlechtert.");
		}

		if (Politik2 > 0)
		{
			FeedbackTicker.GetComponent<FeedbackScript>().NewTick("Das Event hat deine politische Position des Bauhaus um " + Politik2 + " nach rechts verschoben.");
		}
		else
		{
			FeedbackTicker.GetComponent<FeedbackScript>().NewTick("Das Event hat deine politische Position des Bauhaus um " + Politik2 + " nach links verschoben.");
		}

		if (Geld2 > 0)
		{
			FeedbackTicker.GetComponent<FeedbackScript>().NewTick("Das Event hat dir " + Geld2 + " RM eingebracht.");
		}
		else
		{
			FeedbackTicker.GetComponent<FeedbackScript>().NewTick("Durch das Event hast du " + Geld2 * -1 + " RM verloren.");
		}

		IsFinished = true;
		this.gameObject.SetActive(false);
	}
	public void TooLate() //To Apologize
	{
		GameObject.Find("AnsehenCounter").GetComponent<SliderValueToText>().sliderUI.value -= 5;
		GameObject.Find("Money Display").GetComponent<Money>().Geld(-50000);
	}

	public void DecreaseTimerCounter()
	{
		TimerCounter--;

		if ((TimerCounter <= Vorlauf && TimerCounter > 0) && !IsFinished)
		{
			gameObject.SetActive(true);

			GameObject.Find("Button - Event Menu").GetComponent<Button>().interactable = true;
		}
	}
}
