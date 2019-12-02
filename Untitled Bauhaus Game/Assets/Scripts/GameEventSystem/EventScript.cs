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

    void Start()
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

			AllEvents[i].GetComponentsInChildren<Button>()[1].GetComponentInChildren<Text>().text
				= EventLoader.ec.Events[i].EventOption2 + Environment.NewLine
				+ "Ansehensveränderung: " + EventLoader.ec.Events[i].Option2_Ansehen + Environment.NewLine
				+ "Politische Tragweite: " + EventLoader.ec.Events[i].Option2_Politik;
		}
	}

    void Update()
    {
		if (AllEvents.FindAll(actives => actives.activeSelf == false).Count >= AllEvents.Count)
		{
			if (gameObject.activeSelf)
			{
				gameObject.SetActive(false); //Wenn keine Events mehr aktiv sind, blende das Menue aus
				GameObject.Find("Event Menu Button").GetComponent<Button>().interactable = false; //Sorgt dafür, das der Button nicht mehr funktioniert, damit man kein Flackern erzeugen kann
			}
		}
	}

	public void ToggleEvent()
	{
		if (gameObject.activeSelf)
		{
			gameObject.SetActive(false);
		}
		else
		{
			gameObject.SetActive(true);
			GameObject.Find("EventSystem").GetComponent<BaumenuDetail>().detailWindow.SetActive(false); //schließt Baumenu
		}
	}
}
