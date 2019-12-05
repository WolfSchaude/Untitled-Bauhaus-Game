using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventScript : MonoBehaviour
{
	public GameObject prefab;
	public GameObject parent;

	public GameObject UIToBlendIn;

	public static List<GameObject> AllEvents;

	public Text AnzahlEvents;

	private bool AlreadyGenerated = false;

    void Start()
    {
		if (!AlreadyGenerated)
		{
			AllEvents = new List<GameObject>();

			for (int i = 0; i < EventLoader.ec.Events.Count; i++)
			{
				AllEvents.Add(Instantiate(prefab, parent.transform));

				AllEvents[i].GetComponent<Event_Memory>().SetMemory(EventLoader.ec.Events[i]);

				AllEvents[i].GetComponentInChildren<Text>().text = EventLoader.ec.Events[i].EventText;

				AllEvents[i].GetComponentsInChildren<Button>()[0].GetComponentInChildren<Text>().text
					= EventLoader.ec.Events[i].EventOption1 + Environment.NewLine
					+ "Ansehensveränderung: " + EventLoader.ec.Events[i].Option1_Ansehen + Environment.NewLine
					+ "Politische Tragweite: " + EventLoader.ec.Events[i].Option1_Politik;

				if (EventLoader.ec.Events[i].SpezialEvent == 0)
				{
					AllEvents[i].GetComponentsInChildren<Button>()[1].GetComponentInChildren<Text>().text
						= EventLoader.ec.Events[i].EventOption2 + Environment.NewLine
						+ "Ansehensveränderung: " + EventLoader.ec.Events[i].Option2_Ansehen + Environment.NewLine
						+ "Politische Tragweite: " + EventLoader.ec.Events[i].Option2_Politik;
				}
			}
			AlreadyGenerated = true;
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

				AllEvents[i].GetComponentInChildren<Text>().text = EventLoader.ec.Events[i].EventText;

				AllEvents[i].GetComponentsInChildren<Button>()[0].GetComponentInChildren<Text>().text
					= EventLoader.ec.Events[i].EventOption1 + Environment.NewLine
					+ "Ansehensveränderung: " + EventLoader.ec.Events[i].Option1_Ansehen + Environment.NewLine
					+ "Politische Tragweite: " + EventLoader.ec.Events[i].Option1_Politik;

				if (EventLoader.ec.Events[i].SpezialEvent == 0)
				{
					AllEvents[i].GetComponentsInChildren<Button>()[1].GetComponentInChildren<Text>().text
						= EventLoader.ec.Events[i].EventOption2 + Environment.NewLine
						+ "Ansehensveränderung: " + EventLoader.ec.Events[i].Option2_Ansehen + Environment.NewLine
						+ "Politische Tragweite: " + EventLoader.ec.Events[i].Option2_Politik;
				}
			}
			AlreadyGenerated = true;
		}
	}

    void Update()
    {
		if (AllEvents.FindAll(actives => actives.activeSelf == false).Count >= AllEvents.Count)
		{
			if (UIToBlendIn.activeSelf)
			{
				UIToBlendIn.SetActive(false); //Wenn keine Events mehr aktiv sind, blende das Menue aus
				//GameObject.Find("Event Menu Button").GetComponent<Button>().interactable = false; //Sorgt dafür, das der Button nicht mehr funktioniert, damit man kein Flackern erzeugen kann

			}
		}
		if (AllEvents.FindAll(actives => actives.activeSelf == true).Count == 1)
		{
			AnzahlEvents.text = AllEvents.FindAll(actives => actives.activeSelf == true).Count + " Event aktiv";
		}
		else
		{
			AnzahlEvents.text = AllEvents.FindAll(actives => actives.activeSelf == true).Count + " Events aktiv";
		}

	}

	public void ToggleEvent()
	{
		if (UIToBlendIn.activeSelf)
		{
			UIToBlendIn.SetActive(false);
		}
		else
		{
			UIToBlendIn.SetActive(true);
			GameObject.Find("EventSystem").GetComponent<BaumenuDetail>().detailWindow.SetActive(false); //schließt Baumenu
		}
	}
}
