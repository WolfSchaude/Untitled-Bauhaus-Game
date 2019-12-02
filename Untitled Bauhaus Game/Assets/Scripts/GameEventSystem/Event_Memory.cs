using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event_Memory : MonoBehaviour
{
	public int Politik1		= 0;
	public int Ansehen1		= 0;
	public int Politik2		= 0;
	public int Ansehen2		= 0;

	public int Vorlauf		= 90;

	public int Datum_Tag	= 0;
	public int Datum_Monat	= 0;
	public int Datum_Jahr	= 0;

	public int TimerCounter = 0;

	public Text Timer;

	public Event Memory;

	public bool IsFinished = false;

	// Start is called before the first frame update
	void Start()
	{
		Memory = new Event();
	}

	// Update is called once per frame
	void Update()
	{
		if (TimerCounter > Vorlauf)
		{
			this.gameObject.SetActive(false);
			GameObject.Find("EventSystem").GetComponent<Events>().changedDay.RemoveListener(() => { DecreaseTimerCounter(); });
		}
		if (TimerCounter < 0)
		{
			this.gameObject.SetActive(false);
		}

		Timer.text = "Noch " + TimerCounter.ToString() + " Tage";
	}

	public void SetMemory(/*int a, int b, int c, int d, */Event ev)
	{
		Memory = ev;

		Politik1 = Memory.Option1_Politik;
		Politik2 = Memory.Option2_Politik;
		Ansehen1 = Memory.Option1_Ansehen;
		Ansehen2 = Memory.Option2_Ansehen;

		Datum_Tag = Memory.Tag;
		Datum_Monat = Memory.Monat;
		Datum_Jahr = Memory.Jahr;

		GameObject.Find("EventSystem").GetComponent<Events>().changedDay.AddListener(() => { DecreaseTimerCounter(); });

		var TagBuffer = GameObject.Find("Datum").GetComponent<TimeKeeper>().currentDay;
		var MonatBuffer = GameObject.Find("Datum").GetComponent<TimeKeeper>().currentMonth;
		var JahrBuffer = GameObject.Find("Datum").GetComponent<TimeKeeper>().currentYear;

		//if (JahrBuffer > Datum_Jahr)
		//{
		//	TimerCounter += (Datum_Jahr - JahrBuffer) * 365;
		//}
		//if (MonatBuffer >= Datum_Monat + 3 /*&& JahrBuffer == Datum_Jahr && TagBuffer == Datum_Tag*/)
		//{
		//	//this.gameObject.SetActive(false);
		//	TimerCounter += (Datum_Monat - MonatBuffer) * 30;
		//}
		//if (TagBuffer > Datum_Tag)
		//{
		//	TimerCounter += (Datum_Tag - TagBuffer);
		//}


		if (Datum_Tag - TagBuffer >= 0)
		{
			TimerCounter += (Datum_Tag - TagBuffer) * 1;

			{
				if (Datum_Monat - MonatBuffer >= 0)

				{
					TimerCounter += (Datum_Monat - MonatBuffer) * 30;

					{

						if (Datum_Jahr - JahrBuffer >= 0)
						{
							TimerCounter += (Datum_Jahr - JahrBuffer) * 360;
						}
						else
						{
							TimerCounter += (Datum_Jahr + 1 - JahrBuffer - 1) * 360;
						}
					}
				}
				else
				{
					TimerCounter += (Datum_Monat + 12 - MonatBuffer) * 30;

					{

						if (Datum_Jahr - JahrBuffer - 1 >= 0)
						{
							TimerCounter += (Datum_Jahr - JahrBuffer - 1) * 360;
						}
						else
						{
							TimerCounter += (Datum_Jahr + 1 - JahrBuffer - 1) * 360;
						}
					}
				}
			}
		}
		else
		{
			TimerCounter += (Datum_Tag + 30 - TagBuffer) * 1;

			{

				if (Datum_Monat - MonatBuffer >= 0)
				{
					TimerCounter += (Datum_Monat - MonatBuffer) * 30;

					{

						if (Datum_Jahr - JahrBuffer >= 0)
						{
							TimerCounter += (Datum_Jahr - JahrBuffer) * 360;
						}
						else
						{
							TimerCounter += (Datum_Jahr + 1 - JahrBuffer - 1) * 360;
						}
					}
				}
				else
				{
					TimerCounter += (Datum_Monat + 12 - MonatBuffer) * 30;

					{

						if (Datum_Jahr - JahrBuffer - 1 >= 0)
						{
							TimerCounter += (Datum_Jahr - JahrBuffer - 1) * 360;
						}
						else
						{
							TimerCounter += (Datum_Jahr + 1 - JahrBuffer - 1) * 360;
						}
					}
				}
			}
		}

		Vorlauf = 90;

		if (TimerCounter > Vorlauf)
		{
			this.gameObject.SetActive(false);
		}
	}

	public void EventEffect1()
	{
		GameObject.Find("AnsehenCounter").GetComponent<SliderValueToText>().sliderUI.value += Ansehen1;
		GameObject.Find("Politikmeter").GetComponent<Politikmeter>().Politiklevel += Politik1;


		IsFinished = true;
		this.gameObject.SetActive(false);
	}
	public void EventEffect2()
	{
		GameObject.Find("AnsehenCounter").GetComponent<SliderValueToText>().sliderUI.value += Ansehen2;
		GameObject.Find("Politikmeter").GetComponent<Politikmeter>().Politiklevel += Politik2;

		IsFinished = true;
		this.gameObject.SetActive(false);
	}
	public void DecreaseTimerCounter()
	{
		TimerCounter--;

		if ((TimerCounter <= Vorlauf && TimerCounter > 0) && !IsFinished)
		{
			gameObject.SetActive(true);
		}
	}
}