﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventScript : MonoBehaviour
{
	public GameObject FeedbackTicker;

	public GameObject prefab;
	public GameObject randomprefab;
	public GameObject parent;

	public GameObject UIToBlendIn;

	public static List<GameObject> AllEvents;
	public GameObject ThatOneRandomEvent;

	public Text AnzahlEvents;

	public Animator EventsAnimator;

	public bool Collapsed;

	private bool AlreadyGenerated = false;

	private int ActiveEvents;

    void Start()
    {
		if (!AlreadyGenerated)
		{
			AllEvents = new List<GameObject>();

			for (int i = 0; i < EventLoader.ec.Events.Count; i++)
			{
				var x = Instantiate(prefab, parent.transform);

				x.GetComponent<Event_Memory>().SetMemory(EventLoader.ec.Events[i]);
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

			Debug.Log(AllEvents.ToString());
			Debug.Log(AllEvents[0].ToString());
			Debug.Log(AllEvents[0].GetComponent<Event_Memory>().Memory.ToString());
			Debug.Log(AllEvents[0].GetComponent<Event_Memory>().Memory.Option1_EffectTicker.ToString());
			Debug.Log(AllEvents[0].GetComponent<Event_Memory>().Effect1.ToString());


			ThatOneRandomEvent = NewRandomEvent();
		}
	}

    void Update()
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

	public void GenerateList()
	{
		if (!AlreadyGenerated)
		{
			AllEvents = new List<GameObject>();

			for (int i = 0; i < EventLoader.ec.Events.Count; i++)
			{
				AllEvents.Add(Instantiate(prefab, parent.transform));

				AllEvents[i].GetComponent<Event_Memory>().SetMemory(EventLoader.ec.Events[i]);
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
		}
	}

	public GameObject NewRandomEvent()
	{
		var x = Instantiate(randomprefab, parent.transform);

		var rand = UnityEngine.Random.Range(0, EventLoader.rec.RandomEvents.Count);

		x.GetComponent<RandomEvent_Memory>().SetMemory(EventLoader.rec.RandomEvents[rand]);

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
}
