using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Memory : MonoBehaviour
{
	public int Politik1 = 0;
	public int Ansehen1 = 0;
	public int Politik2 = 0;
	public int Ansehen2 = 0;

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

	public void SetMemory(int a, int b, int c, int d, Event ev)
	{
		Politik1 = a;
		Politik2 = c;
		Ansehen1 = b;
		Ansehen2 = d;
		Memory = ev;
	}

	public void EventEffect1()
	{
		GameObject.Find("AnsehenCounter").GetComponent<SliderValueToText>().sliderUI.value += Ansehen1;
		GameObject.Find("Politikmeter").GetComponent<Politikmeter>().Politiklevel += Politik1;

		this.gameObject.SetActive(false);
	}
	public void EventEffect2()
	{
		GameObject.Find("AnsehenCounter").GetComponent<SliderValueToText>().sliderUI.value += Ansehen2;
		GameObject.Find("Politikmeter").GetComponent<Politikmeter>().Politiklevel += Politik2;

		this.gameObject.SetActive(false);
	}
}