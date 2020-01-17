﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventScript : MonoBehaviour, ISaveableInterface
{
	public GameObject FeedbackTicker;

	public GameObject prefab;
	public GameObject randomprefab;
	public GameObject parent;

	public GameObject UIToBlendIn;
	public GameObject Playervariables;
	public GameObject SaveGamemanager;

	public static List<GameObject> AllEvents;
	private GameObject ThatOneRandomEvent;

	public Text AnzahlEvents;

	public Animator EventsAnimator;

	public bool Collapsed;

	private bool AlreadyGenerated = false;

	private int ActiveEvents;

	List<bool> AlreadyFinished;

	bool Laedtgerade;

    void Start()
    {
		Laedtgerade = GameObject.Find("SceneSwitcher").GetComponent<SaveGameLoader>().LoadSaveGame;
		if (!Laedtgerade)
		{
			Debug.Log("Generated by Start Method");

			if (!AlreadyGenerated)
			{
				AllEvents = new List<GameObject>();

				for (int i = 0; i < EventLoader.ec.Events.Count; i++)
				{
					var x = Instantiate(prefab, parent.transform);

					x.GetComponent<Event_Memory>().SetMemory(EventLoader.ec.Events[i], Playervariables, false);
					x.GetComponent<Event_Memory>().FeedbackTicker = FeedbackTicker;

					x.GetComponentInChildren<Text>().text = EventLoader.ec.Events[i].EventText;

					x.GetComponentsInChildren<Button>()[0].GetComponentInChildren<Text>().text
						= EventLoader.ec.Events[i].EventOption1 + Environment.NewLine
						+ "Ansehensveränderung: " + EventLoader.ec.Events[i].Option1_Ansehen + Environment.NewLine
						+ "Politische Tragweite: " + EventLoader.ec.Events[i].Option1_Politik;

					if (EventLoader.ec.Events[i].Exponate_Needed == 0)
					{
						x.GetComponentsInChildren<Button>()[1].GetComponentInChildren<Text>().text
							= EventLoader.ec.Events[i].EventOption2 + Environment.NewLine
							+ "Ansehensveränderung: " + EventLoader.ec.Events[i].Option2_Ansehen + Environment.NewLine
							+ "Politische Tragweite: " + EventLoader.ec.Events[i].Option2_Politik;
					}

					AllEvents.Add(x);

					x = null;
				}
				AlreadyGenerated = true;
				Collapsed = true;


				ThatOneRandomEvent = NewRandomEvent();
			}
		}
		AlreadyFinished = new List<bool>();
	}

    void Update()
    {
		if (!Laedtgerade)
		{
			ActiveEvents = AllEvents.FindAll(actives => actives.activeSelf == true).Count;
			if (ThatOneRandomEvent.activeSelf)
			{
				ActiveEvents++;
			}

			if (AllEvents.FindAll(actives => actives.activeSelf == false).Count >= AllEvents.Count && !ThatOneRandomEvent.activeSelf)
			{
				if (!Collapsed)
				{
					EventsAnimator.SetTrigger("Click");

					Collapsed = true;
				}
			}
			if (ActiveEvents == 1)
			{
				AnzahlEvents.text = ActiveEvents + " Event aktiv";
			}
			else
			{
				AnzahlEvents.text = ActiveEvents + " Events aktiv";
			}

			if (ThatOneRandomEvent.GetComponent<RandomEvent_Memory>().IsFinished)
			{
				ThatOneRandomEvent = NewRandomEvent();
			}
		}

		foreach (var Event in AllEvents)
		{
			if (Event.GetComponent<Event_Memory>().TimerCounter == 7)
			{
				OpenEvent();
			}
		}
	}

	public void GenerateList(bool[] save)
	{
		Debug.Log("Generated by Savegame");

		if (!AlreadyGenerated)
		{
			AllEvents = new List<GameObject>();

			for (int i = 0; i < EventLoader.ec.Events.Count; i++)
			{
				AllEvents.Add(Instantiate(prefab, parent.transform));

				AllEvents[i].GetComponent<Event_Memory>().SetMemory(EventLoader.ec.Events[i], Playervariables, save[i]);
				AllEvents[i].GetComponent<Event_Memory>().FeedbackTicker = FeedbackTicker;

				AllEvents[i].GetComponentInChildren<Text>().text = EventLoader.ec.Events[i].EventText;

				AllEvents[i].GetComponentsInChildren<Button>()[0].GetComponentInChildren<Text>().text
					= EventLoader.ec.Events[i].EventOption1 + Environment.NewLine
					+ "Ansehensveränderung: " + EventLoader.ec.Events[i].Option1_Ansehen + Environment.NewLine
					+ "Politische Tragweite: " + EventLoader.ec.Events[i].Option1_Politik;

				if (EventLoader.ec.Events[i].Exponate_Needed == 0)
				{
					AllEvents[i].GetComponentsInChildren<Button>()[1].GetComponentInChildren<Text>().text
						= EventLoader.ec.Events[i].EventOption2 + Environment.NewLine
						+ "Ansehensveränderung: " + EventLoader.ec.Events[i].Option2_Ansehen + Environment.NewLine
						+ "Politische Tragweite: " + EventLoader.ec.Events[i].Option2_Politik;
				}
			}
			AlreadyGenerated = true;

			ThatOneRandomEvent = NewRandomEvent();

			ActiveEvents = AllEvents.FindAll(actives => actives.activeSelf == true).Count;
			if (ThatOneRandomEvent.activeSelf)
			{
				ActiveEvents++;
			}

			if (AllEvents.FindAll(actives => actives.activeSelf == false).Count >= AllEvents.Count && !ThatOneRandomEvent.activeSelf)
			{
				if (!Collapsed)
				{
					EventsAnimator.SetTrigger("Click");

					Collapsed = true;
				}
			}
			if (ActiveEvents == 1)
			{
				AnzahlEvents.text = ActiveEvents + " Event aktiv";
			}
			else
			{
				AnzahlEvents.text = ActiveEvents + " Events aktiv";
			}

			Laedtgerade = false;
		}
	}

	public GameObject NewRandomEvent()
	{
		var x = Instantiate(randomprefab, parent.transform);

		var rand = UnityEngine.Random.Range(0, EventLoader.rec.RandomEvents.Count);

		x.GetComponent<RandomEvent_Memory>().SetMemory(EventLoader.rec.RandomEvents[rand], Playervariables);

		x.GetComponent<RandomEvent_Memory>().FeedbackTicker = FeedbackTicker;

		x.GetComponentInChildren<Text>().text = EventLoader.rec.RandomEvents[rand].EventText;

		x.GetComponentsInChildren<Button>()[0].GetComponentInChildren<Text>().text
					= EventLoader.rec.RandomEvents[rand].EventOption1 + Environment.NewLine
					+ "Ansehensveränderung: " + EventLoader.rec.RandomEvents[rand].Option1_Ansehen + Environment.NewLine
					+ "Politische Tragweite: " + EventLoader.rec.RandomEvents[rand].Option1_Politik;

		x.GetComponentsInChildren<Button>()[1].GetComponentInChildren<Text>().text
					= EventLoader.rec.RandomEvents[rand].EventOption2 + Environment.NewLine
					+ "Ansehensveränderung: " + EventLoader.rec.RandomEvents[rand].Option2_Ansehen + Environment.NewLine
					+ "Politische Tragweite: " + EventLoader.rec.RandomEvents[rand].Option2_Politik;

		return x;
	}

	public void ToggleEvent()
	{
		EventsAnimator.SetTrigger("Click");

		Collapsed = !Collapsed;
	}

	public void CloseEvent()
	{
		if (!Collapsed)
		{
			EventsAnimator.SetTrigger("Click");

			Collapsed = true;
		}
	}

	public void OpenEvent()
	{
		if (Collapsed)
		{
			EventsAnimator.SetTrigger("Click");

			Collapsed = false;
		}
	}

	public void Save()
	{
		var x = new bool[AllEvents.Count];
		for (int i = 0; i < AllEvents.Count; i++)
		{
			x[i] = AllEvents[i].GetComponent<Event_Memory>().IsFinished;
		}

		SaveGamemanager.GetComponent<SaveGameManager>().Savestate.IsEventFinished = x;
		SaveGamemanager.GetComponent<SaveGameManager>().WhoHasSaved[7] = true;
	}

	public void Load(Save save)
	{
		GenerateList(save.IsEventFinished);
	}
}
