using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Memory : MonoBehaviour
{
	public Event Memory;

	// Start is called before the first frame update
	void Start()
	{
		Memory = new Event();
	}

	// Update is called once per frame
	void Update()
	{

	}

	public Event_Memory(Event ev)
	{
		Memory = ev;
	}

	public void SetMemory(Event ev)
	{
		Memory = ev;
	}
}