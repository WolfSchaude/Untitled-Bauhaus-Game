using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomEvent_Memory : MonoBehaviour
{
	public int Vorlauf = 90;

	public int TimerCounter = 0;

	public Text Timer;

	[SerializeField] public Event Memory;

	[SerializeField] public bool IsFinished = false;

	[SerializeField] private bool SelectedOption1 = false;
	[SerializeField] private bool SelectedOption2 = false;

	public GameObject Playervariables;

	public Button Option1;
	public Button Option2;

	public Sprite SpriteNormal;
	public Sprite SpriteSelected;

	void Start()
    {
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

    public void SetMemory(Event rev, GameObject PlayerStats)
    {
		Playervariables = PlayerStats;

		Memory = rev;

		GameObject.Find("PlayerVariables").GetComponent<NewTimeKeeper>().NewDay.AddListener(() => { DecreaseTimerCounter(); });

		TimerCounter = Random.Range(90, 180);

		Vorlauf = 90;

		if (TimerCounter > Vorlauf)
		{
			this.gameObject.SetActive(false);
		}
	}

	public void SelectOption1()
	{
		SelectedOption1 = true;

		if (SelectedOption2)
		{
			SelectedOption2 = false;
			Option2.image.sprite = SpriteNormal;
		}

		Option1.image.sprite = SpriteSelected;
	}
	public void SelectOption2()
	{
		SelectedOption2 = true;

		if (SelectedOption1)
		{
			SelectedOption1 = false;
			Option1.image.sprite = SpriteNormal;
		}

		Option2.image.sprite = SpriteSelected;
	}
	private void EventEffect1()
	{
		Playervariables.GetComponent<AnsehenScript>().ManipulateAnsehen(Memory.Option1_Ansehen);
		Playervariables.GetComponent<Politikmeter>().ManipulatePolitics(Memory.Option1_Politik);
		Playervariables.GetComponent<Money>().Geld(Memory.Option1_Geld);

		Ticker.NewTick.Invoke(Memory.Option1_EffectTicker);

		IsFinished = true;
		this.gameObject.SetActive(false);
	}
	private void EventEffect2()
	{
		Playervariables.GetComponent<AnsehenScript>().ManipulateAnsehen(Memory.Option2_Ansehen);
		Playervariables.GetComponent<Politikmeter>().ManipulatePolitics(Memory.Option2_Politik);
		Playervariables.GetComponent<Money>().Geld(Memory.Option2_Geld);

		Ticker.NewTick.Invoke(Memory.Option2_EffectTicker);

		IsFinished = true;
		this.gameObject.SetActive(false);
	}
	public void TooLate() //To Apologize
	{
		Playervariables.GetComponent<AnsehenScript>().ManipulateAnsehen(-5);
		Playervariables.GetComponent<Money>().Geld(-50000);
	}

	public void DecreaseTimerCounter()
	{
		TimerCounter--;

		if ((TimerCounter <= Vorlauf && TimerCounter > 0) && !IsFinished)
		{
			gameObject.SetActive(true);

			GameObject.Find("Button - Event Menu").GetComponent<Button>().interactable = true;
		}
	}
}
