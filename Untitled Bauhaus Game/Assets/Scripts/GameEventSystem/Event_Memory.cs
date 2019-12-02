using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event_Memory : MonoBehaviour
{
	public int Politik1				= 0;
	public int Politik2				= 0;
	public int Ansehen1				= 0;
	public int Ansehen2				= 0;
	public int Geld1				= 0;
	public int Geld2				= 0;

	public int Vorlauf				= 90;

	public int Datum_Tag			= 0;
	public int Datum_Monat			= 0;
	public int Datum_Jahr			= 0;

	public int TimerCounter			= 0;

	public Text Timer;

	public Event Memory;

	public bool IsFinished			= false;

	private bool SelectedOne		= false;
	private bool SelectedOption1	= false;
	private bool SelectedOption2	= false;

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

		Timer.text = "Noch " + TimerCounter.ToString() + " Tage";
	}

	public void SetMemory(Event ev)
	{
		Memory = ev;

		Politik1 = Memory.Option1_Politik;
		Politik2 = Memory.Option2_Politik;
		Ansehen1 = Memory.Option1_Ansehen;
		Ansehen2 = Memory.Option2_Ansehen;
		Geld1 = Memory.Option1_Geld;
		Geld2 = Memory.Option2_Geld;

		Datum_Tag = Memory.Starten_Tag;
		Datum_Monat = Memory.Starten_Monat;
		Datum_Jahr = Memory.Starten_Jahr;

		GameObject.Find("EventSystem").GetComponent<Events>().changedDay.AddListener(() => { DecreaseTimerCounter(); });

		var TagBuffer = GameObject.Find("Datum").GetComponent<TimeKeeper>().currentDay;
		var MonatBuffer = GameObject.Find("Datum").GetComponent<TimeKeeper>().currentMonth;
		var JahrBuffer = GameObject.Find("Datum").GetComponent<TimeKeeper>().currentYear;

		{
			/*
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
			*/
		}

		TimerCounter = BerechneTage(TagBuffer, MonatBuffer, JahrBuffer, Datum_Tag, Datum_Monat, Datum_Jahr);

		Vorlauf = 90;

		if (TimerCounter > Vorlauf)
		{
			this.gameObject.SetActive(false);
		}
	}

	public static int BerechneTage(int StartTag, int StartMonat, int Startjahr, int EndTag, int EndMonat, int EndJahr)
	{
		int Buffer = 0;

		if (EndTag - StartTag >= 0)
		{
			Buffer += (EndTag - StartTag) * 1;
			{
				if (EndMonat - StartMonat >= 0)
				{
					Buffer += (EndMonat - StartMonat) * 30;
					{
						if (EndJahr - Startjahr >= 0)
						{
							Buffer += (EndJahr - Startjahr) * 360;
						}
						else
						{
							Buffer += (EndJahr + 1 - Startjahr - 1) * 360;
						}
					}
				}
				else
				{
					Buffer += (EndMonat + 12 - StartMonat) * 30;
					{
						if (EndJahr - Startjahr - 1 >= 0)
						{
							Buffer += (EndJahr - Startjahr - 1) * 360;
						}
						else
						{
							Buffer += (EndJahr + 1 - Startjahr - 1) * 360;
						}
					}
				}
			}
		}
		else
		{
			Buffer += (EndTag + 30 - StartTag) * 1;
			{
				if (EndMonat - StartMonat >= 0)
				{
					Buffer += (EndMonat - StartMonat) * 30;
					{
						if (EndJahr - Startjahr >= 0)
						{
							Buffer += (EndJahr - Startjahr) * 360;
						}
						else
						{
							Buffer += (EndJahr + 1 - Startjahr - 1) * 360;
						}
					}
				}
				else
				{
					Buffer += (EndMonat + 12 - StartMonat) * 30;
					{
						if (EndJahr - Startjahr - 1 >= 0)
						{
							Buffer += (EndJahr - Startjahr - 1) * 360;
						}
						else
						{
							Buffer += (EndJahr + 1 - Startjahr - 1) * 360;
						}
					}
				}
			}
		}

		return Buffer;
	}

	public void SelectOption1()
	{
		if (!SelectedOne)
		{
			SelectedOption1 = true;
			SelectedOne = true;
			gameObject.GetComponentsInChildren<Button>()[0].interactable = false;
			gameObject.GetComponentsInChildren<Button>()[0].Select();

			var colours = gameObject.GetComponentsInChildren<Button>()[0].colors;	//Highlight Button with a different Color
			colours.disabledColor = new Color32(155, 0, 0, 255);
			gameObject.GetComponentsInChildren<Button>()[0].colors = colours;

			gameObject.GetComponentsInChildren<Button>()[1].interactable = false;
			gameObject.GetComponentsInChildren<Button>()[1].Select();
		}
	}

	public void SelectOption2()
	{
		if (!SelectedOne)
		{
			SelectedOption2 = true;
			SelectedOne = true;
			gameObject.GetComponentsInChildren<Button>()[0].interactable = false;
			gameObject.GetComponentsInChildren<Button>()[0].Select();
			gameObject.GetComponentsInChildren<Button>()[1].interactable = false;
			gameObject.GetComponentsInChildren<Button>()[1].Select();

			var colours = gameObject.GetComponentsInChildren<Button>()[1].colors;   //Highlight Button with a different Color
			colours.disabledColor = new Color32(155, 0, 0, 255);
			gameObject.GetComponentsInChildren<Button>()[1].colors = colours;
		}
	}

	private void EventEffect1()
	{
		GameObject.Find("AnsehenCounter").GetComponent<SliderValueToText>().sliderUI.value += Ansehen1;
		GameObject.Find("Politikmeter").GetComponent<Politikmeter>().Politiklevel += Politik1;
		GameObject.Find("Money Display").GetComponent<Money>().Geld(Geld1);

		IsFinished = true;
		this.gameObject.SetActive(false);
	}
	private void EventEffect2()
	{
		GameObject.Find("AnsehenCounter").GetComponent<SliderValueToText>().sliderUI.value += Ansehen2;
		GameObject.Find("Politikmeter").GetComponent<Politikmeter>().Politiklevel += Politik2;
		GameObject.Find("Money Display").GetComponent<Money>().Geld(Geld2);

		IsFinished = true;
		this.gameObject.SetActive(false);
	}
	public void TooLate() //To Apologize
	{
		GameObject.Find("AnsehenCounter").GetComponent<SliderValueToText>().sliderUI.value -= 5;
		GameObject.Find("Money Display").GetComponent<Money>().Geld(-50000);
	}
	public void DecreaseTimerCounter()
	{
		TimerCounter--;

		if ((TimerCounter <= Vorlauf && TimerCounter > 0) && !IsFinished)
		{
			gameObject.SetActive(true);
			GameObject.Find("Event Menu Button").GetComponent<Button>().interactable = true;
		}
	}
}