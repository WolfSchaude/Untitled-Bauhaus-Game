using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCard : MonoBehaviour
{
	public static bool isEvent = false;

	public GameObject EventMenuUI;

    void Start()
	{
		gameObject.SetActive(false);
	}
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (!isEvent)
			{
				TriggerEvent();
			}

		}
    }
	public void TriggerEvent()
	{
		if (!isEvent)
		{
			isEvent = true;
			//EventMenuUI.SetActive(true);
			this.gameObject.SetActive(true);
			Time.timeScale = 0f;
		}
	}
	public void EndEvent()
	{
		if (isEvent)
		{
			isEvent = false;
			EventMenuUI.SetActive(false);
			gameObject.SetActive(false);
			Time.timeScale = 1f;
		}
	}
}
