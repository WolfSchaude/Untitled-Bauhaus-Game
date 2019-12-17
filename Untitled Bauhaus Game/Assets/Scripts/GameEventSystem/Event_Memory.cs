﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event_Memory : MonoBehaviour
{
	public int Politik1					= 0;
	public int Politik2					= 0;
	public int Ansehen1					= 0;
	public int Ansehen2					= 0;
	public int Geld1					= 0;
	public int Geld2					= 0;
	public string Effect1				= "";
	public string Effect2				= "";

	public int Vorlauf					= 90;

	public int Datum_Tag				= 0;
	public int Datum_Monat				= 0;
	public int Datum_Jahr				= 0;
	
	public int TimerCounter				= 0;

	public Text Timer;

	public Event Memory;

	public bool IsFinished				= false;

	public bool SelectedOption1			= false;
	public bool SelectedOption2			= false;

	public bool ExponateCounterStartet	= false;
	public int ExponateCounter			= 0;
	public int ExponateNeeded			= 0;

	public GameObject FeedbackTicker;

	public Button Option1;
	public Button Option2;

	public Sprite SpriteNormal;
	public Sprite SpriteSelected;

	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		if (Memory == null) Start();

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

		if (TimerCounter == 7)
		{
			GameObject.Find("Button - Event Menu").GetComponent<EventScript>().OpenEvent();
		}

		if (TimerCounter <= Vorlauf && TimerCounter > 0 && ExponateNeeded != 0 && !ExponateCounterStartet)
		{
			ExponateCounterFunktion();
		}
		if (ExponateCounterStartet)
		{
			gameObject.GetComponentsInChildren<Button>()[0].GetComponentInChildren<Text>().text = ExponateCounter + " von " + ExponateNeeded + " Exponaten hergestellt.";
		}
		if (ExponateCounter >= ExponateNeeded && ExponateNeeded != 0 && ExponateCounterStartet)
		{
			SelectOption1();
		}

		Timer.text = "Noch " + TimerCounter.ToString() + " Tage";
	}

	public void SetMemory(Event ev)
	{
		Memory = ev;

		Politik1 = Memory.Option1_Politik;
		Politik2 = Memory.Option2_Politik;
		Ansehen1 = Memory.Option1_Ansehen;
		Ansehen2 = Memory.Option2_Ansehen;
		Geld1 = Memory.Option1_Geld;
		Geld2 = Memory.Option2_Geld;
		Effect1 = Memory.Option1_EffectTicker;
		Effect2 = Memory.Option2_EffectTicker;

		Datum_Tag = Memory.Event_Tag;
		Datum_Monat = Memory.Event_Monat;
		Datum_Jahr = Memory.Event_Jahr;

		GameObject.Find("EventSystem").GetComponent<DatumRelatedEvents>().changedDay.AddListener(() => { DecreaseTimerCounter(); });

		var x = GameObject.Find("Datum").GetComponent<TimeKeeper>();

		var TagBuffer = x.currentDay;
		var MonatBuffer = x.currentMonth;
		var JahrBuffer = x.currentYear;

		TimerCounter = BerechneTage(TagBuffer, MonatBuffer, JahrBuffer, Datum_Tag, Datum_Monat, Datum_Jahr);
		
		//Wenn ein spezielles Einblenddatum gegeben ist, wird das berechnet, ansonsten werden 90 Tage verwendet 
		if (Memory.Einblenden_Ab_Tag != 0 && ( Memory.Einblenden_Ab_Monat != 0 && Memory.Einblenden_Ab_Jahr != 0))
		{
			Vorlauf = BerechneTage(Memory.Einblenden_Ab_Tag, Memory.Einblenden_Ab_Monat, Memory.Einblenden_Ab_Jahr, Datum_Tag, Datum_Monat, Datum_Jahr);
		}
		else
		{
			Vorlauf = 90;
		}

		if (TimerCounter > Vorlauf)
		{
			this.gameObject.SetActive(false);
		}

		if (Memory.Exponate_Needed != 0)
		{
			ExponateNeeded = Memory.Exponate_Needed;
		}
	}

	public static int BerechneTage(int StartTag, int StartMonat, int Startjahr, int EndTag, int EndMonat, int EndJahr)
	{
		return ((EndTag + (EndMonat * 30) + (EndJahr * 360)) - (StartTag + (StartMonat * 30) + (Startjahr * 360)));
	}

	public void SelectOption1()
	{
		SelectedOption1 = true;

		if (SelectedOption2)
		{
			SelectedOption2 = false;
			Option2.image.sprite = SpriteNormal;
		}

		Option1.image.sprite = SpriteSelected; ;

		if (ExponateNeeded != 0)
		{
			gameObject.GetComponentsInChildren<Button>()[1].interactable = false;
			gameObject.GetComponentsInChildren<Button>()[1].Select();
		}
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

		FeedbackTicker.GetComponent<FeedbackScript>().NewTick(Effect1);

		/*
		if (Ansehen1 > 0)
		{
			FeedbackTicker.GetComponent<FeedbackScript>().NewTick("Das Event hat dein Ansehen um " + Ansehen1 + " verbessert.");
		}
		else
		{
			if (Ansehen1 < 0)
			{
				FeedbackTicker.GetComponent<FeedbackScript>().NewTick("Das Event hat dein Ansehen um " + Ansehen1 * -1 + " verschlechtert.");
			}
		}

		if (Politik1 > 0)
		{
			FeedbackTicker.GetComponent<FeedbackScript>().NewTick("Das Event hat deine politische Position des Bauhaus um " + Politik1 + " nach rechts verschoben.");
		}
		else
		{
			if (Politik1 < 0)
			{
				FeedbackTicker.GetComponent<FeedbackScript>().NewTick("Das Event hat deine politische Position des Bauhaus um " + Politik1 * -1 + " nach links verschoben.");
			}
		}

		if (Geld1 > 0)
		{
			FeedbackTicker.GetComponent<FeedbackScript>().NewTick("Das Event hat dir " + Geld1  + " RM eingebracht.");
		}
		else
		{
			if (Geld1 < 0)
			{
				FeedbackTicker.GetComponent<FeedbackScript>().NewTick("Durch das Event hast du " + Geld1 * -1 + " RM verloren.");
			}
		}
		*/

		IsFinished = true;
		this.gameObject.SetActive(false);
	}
	private void EventEffect2()
	{
		//GameObject.Find("AnsehenCounter").GetComponent<SliderValueToText>().sliderUI.value += Ansehen2;
		//GameObject.Find("AnsehenCounter").GetComponent<AnsehenScript>().ManipulateAnsehen(Ansehen2);
		GameObject.Find("AnsehenCounter").GetComponent<AnsehenScript>().ManipulateAnsehen(Memory.Option2_Ansehen);
		//GameObject.Find("Politikmeter").GetComponent<Politikmeter>().Politiklevel += Politik2;
		GameObject.Find("Politikmeter").GetComponent<Politikmeter>().Politiklevel += Memory.Option2_Politik;
		//GameObject.Find("Money Display").GetComponent<Money>().Geld(Geld2);
		GameObject.Find("Money Display").GetComponent<Money>().Geld(Memory.Option2_Geld);

		//FeedbackTicker.GetComponent<FeedbackScript>().NewTick(Effect2);
		FeedbackTicker.GetComponent<FeedbackScript>().NewTick(Memory.Option2_EffectTicker);

		/*
		if (Ansehen2 > 0)
		{
			FeedbackTicker.GetComponent<FeedbackScript>().NewTick("Das Event hat dein Ansehen um " + Ansehen2 + " verbessert.");
		}
		else
		{
			if (Ansehen2 < 0)
			{
				FeedbackTicker.GetComponent<FeedbackScript>().NewTick("Das Event hat dein Ansehen um " + Ansehen2 * -1 + " verschlechtert.");
			}
		}

		if (Politik2 > 0)
		{
			FeedbackTicker.GetComponent<FeedbackScript>().NewTick("Das Event hat deine politische Position des Bauhaus um " + Politik2 + " nach rechts verschoben.");
		}
		else
		{
			if (Politik2 < 0)
			{
				FeedbackTicker.GetComponent<FeedbackScript>().NewTick("Das Event hat deine politische Position des Bauhaus um " + Politik2 * -1 + " nach links verschoben.");
			}
		}

		if (Geld2 > 0)
		{
			FeedbackTicker.GetComponent<FeedbackScript>().NewTick("Das Event hat dir " + Geld2 + " RM eingebracht.");
		}
		else
		{
			if (Geld2 < 0)
			{
				FeedbackTicker.GetComponent<FeedbackScript>().NewTick("Durch das Event hast du " + Geld2 * -1 + " RM verloren.");
			}
		}
		*/

		IsFinished = true;
		this.gameObject.SetActive(false);
	}
	public void TooLate() //To Apologize
	{
		//GameObject.Find("AnsehenCounter").GetComponent<SliderValueToText>().sliderUI.value -= 5;

		GameObject.Find("AnsehenCounter").GetComponent<AnsehenScript>().ManipulateAnsehen(-5);

		FeedbackTicker.GetComponent<FeedbackScript>().NewTick("Das Event zu verpassen hat dein Ansehen um 5 verschlechtert.");

		GameObject.Find("Money Display").GetComponent<Money>().Geld(-5000);

		FeedbackTicker.GetComponent<FeedbackScript>().NewTick("Durch das verpasste Event hast du 5000 RM verloren.");
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

	public void ExponateCounterFunktion()
	{
		ExponateCounterStartet = true;

		FindInActiveObjectByName("ExponatSlider").GetComponent<Exponate>().exponatDone.AddListener(() => { IncreaseExponateCounter(); });

		gameObject.GetComponentsInChildren<Button>()[0].interactable = false;
		gameObject.GetComponentsInChildren<Button>()[1].gameObject.SetActive(false);
	}

	public void IncreaseExponateCounter()
	{
		if (ExponateCounterStartet)
		{
			ExponateCounter++;
		}
	}

	public static GameObject FindInActiveObjectByName(string name)
	{
		Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
		for (int i = 0; i < objs.Length; i++)
		{
			if (objs[i].hideFlags == HideFlags.None)
			{
				if (objs[i].name == name)
				{
					return objs[i].gameObject;
				}
			}
		}
		return null;
	}
}