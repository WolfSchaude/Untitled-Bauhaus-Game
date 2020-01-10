using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event_Memory : MonoBehaviour
{
	public int Vorlauf = 90;

	public int TimerCounter = 0;

	public Text Timer;

	public Event Memory;

	[SerializeField] private bool IsFinished				= false;

	[SerializeField] private bool SelectedOption1			= false;
	[SerializeField] private bool SelectedOption2			= false;

	[SerializeField] private bool ExponateCounterStartet	= false;

	[SerializeField] private int ExponateCounter			= 0;
	[SerializeField] private int ExponateNeeded				= 0;

	public GameObject FeedbackTicker;
	public GameObject Playervariables;


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

	public void SetMemory(Event ev, GameObject PlayerStats)
	{
		Playervariables = PlayerStats;

		Memory = ev;

		var x = GameObject.Find("PlayerVariables").GetComponent<NewTimeKeeper>();

		x.NewDay.AddListener(() => { DecreaseTimerCounter(); });

		var TagBuffer = x.CurrentDay;
		var MonatBuffer = x.CurrentMonth;
		var JahrBuffer = x.CurrentYear;

		TimerCounter = NewTimeKeeper.BerechneTage(TagBuffer, MonatBuffer, JahrBuffer, Memory.Event_Tag, Memory.Event_Monat, Memory.Event_Jahr);
		
		//Wenn ein spezielles Einblenddatum gegeben ist, wird das berechnet, ansonsten werden 90 Tage verwendet 
		if (Memory.Einblenden_Ab_Tag != 0 && ( Memory.Einblenden_Ab_Monat != 0 && Memory.Einblenden_Ab_Jahr != 0))
		{
			Vorlauf = NewTimeKeeper.BerechneTage(Memory.Einblenden_Ab_Tag, Memory.Einblenden_Ab_Monat, Memory.Einblenden_Ab_Jahr, Memory.Event_Tag, Memory.Event_Monat, Memory.Event_Jahr);
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
			gameObject.GetComponentsInChildren<Button>()[0].interactable = false;
			gameObject.GetComponentsInChildren<Button>()[0].Select();
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
		Playervariables.GetComponent<AnsehenScript>().ManipulateAnsehen(Memory.Option1_Ansehen);
		Playervariables.GetComponent<Politikmeter>().Politiklevel += Memory.Option1_Politik;
		Playervariables.GetComponent<Money>().Geld(Memory.Option1_Geld);

		FeedbackTicker.GetComponent<FeedbackScript>().NewTick(Memory.Option1_EffectTicker);

		IsFinished = true;
		this.gameObject.SetActive(false);
	}
	private void EventEffect2()
	{
		Playervariables.GetComponent<AnsehenScript>().ManipulateAnsehen(Memory.Option2_Ansehen);
		Playervariables.GetComponent<Politikmeter>().Politiklevel += Memory.Option2_Politik;
		Playervariables.GetComponent<Money>().Geld(Memory.Option2_Geld);

		FeedbackTicker.GetComponent<FeedbackScript>().NewTick(Memory.Option2_EffectTicker);

		IsFinished = true;
		this.gameObject.SetActive(false);
	}
	public void TooLate() //To Apologize
	{
		Playervariables.GetComponent<AnsehenScript>().ManipulateAnsehen(-5);

		FeedbackTicker.GetComponent<FeedbackScript>().NewTick("Das Event zu verpassen hat dein Ansehen um 5 verschlechtert.");

		Playervariables.GetComponent<Money>().Geld(-5000);

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