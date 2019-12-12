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

	public bool SelectedOption1 = false;
	public bool SelectedOption2 = false;

	public GameObject FeedbackTicker;

	public Button Option1;
	public Button Option2;

	public Sprite SpriteNormal;
	public Sprite SpriteSelected;

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
		SelectedOption1 = true;

		if (SelectedOption2)
		{
			SelectedOption2 = false;
			Option2.image.sprite = SpriteNormal;
		}

		Option1.image.sprite = SpriteSelected;
	}
	public void SelectOption2()
	{
		SelectedOption2 = true;

		if (SelectedOption1)
		{
			SelectedOption1 = false;
			Option1.image.sprite = SpriteNormal;
		}

		Option2.image.sprite = SpriteSelected;
	}
	private void EventEffect1()
	{
		//GameObject.Find("AnsehenCounter").GetComponent<SliderValueToText>().sliderUI.value += Ansehen1;
		GameObject.Find("AnsehenCounter").GetComponent<AnsehenScript>().ManipulateAnsehen(Ansehen1);
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
		//GameObject.Find("AnsehenCounter").GetComponent<SliderValueToText>().sliderUI.value += Ansehen2;
		GameObject.Find("AnsehenCounter").GetComponent<AnsehenScript>().ManipulateAnsehen(Ansehen2);
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
		//GameObject.Find("AnsehenCounter").GetComponent<SliderValueToText>().sliderUI.value -= 5;
		GameObject.Find("AnsehenCounter").GetComponent<AnsehenScript>().ManipulateAnsehen(-5);
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
