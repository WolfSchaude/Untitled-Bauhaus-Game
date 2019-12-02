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

    // Start is called before the first frame update
    void Start()
    {
		AllEvents = new List<GameObject>();

		for (int i = 0; i < EventLoader.ec.Events.Count; i++)
		{
			AllEvents.Add(Instantiate(prefab, parent.transform));
			//AllEvents[i].AddComponent<Event_Memory>();
			AllEvents[i].GetComponent<Event_Memory>().SetMemory(
				//EventLoader.ec.Events[i].Option1_Politik,
				//EventLoader.ec.Events[i].Option2_Politik,
				//EventLoader.ec.Events[i].Option1_Ansehen,
				//EventLoader.ec.Events[i].Option2_Ansehen,
				EventLoader.ec.Events[i]);

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

    // Update is called once per frame
    void Update()
    {
		
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
