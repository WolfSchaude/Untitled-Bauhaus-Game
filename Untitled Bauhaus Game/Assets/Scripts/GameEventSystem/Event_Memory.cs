using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class EventSaveClass
{
	public int TimeLeft;
	public int TimeMax;

	public bool Option1;
	public bool Option2;

	public EventSaveClass(int timeLeft, int timeMax, bool option1, bool option2)
	{
		TimeLeft = timeLeft;
		TimeMax = timeMax;

		Option1 = option1;
		Option2 = option2;
	}
}

public class Event_Memory : MonoBehaviour
{
	public int Vorlauf = 0;

	public int TimerCounter = 0;

	public Event Memory;

	public bool IsFinished { private set; get; } = false;

	public bool SelectedOption1 { get; private set; } = false;
	public bool SelectedOption2 { get; private set; } = false;

	/// <Summary>
	/// Dieses Event wird genutzt um verschiedenen Spezialevents das ablaufen der Zeit mitzuteilen
	/// </Summary>
	public UnityEvent TimeIsUp;

	//Referenzen, die fuer die einzelnen Funktionalitaeten gebraucht werden
	public GameObject FeedbackTicker;
	public GameObject Playervariables;

	public Text Timer;

	public Button Option1;
	public Button Option2;

	public Sprite SpriteNormal;
	public Sprite SpriteSelected;

	void Start()
	{
		//Fuege dich zum Event hinzu
		TimeIsUp.AddListener(() => { TriggerTheEffect(); }) ;
	}

	void Update()
	{
		//Wenn es noch laenger als der Vorlauf ist, dann blende das Event aus
		if (TimerCounter > Vorlauf)
		{
			this.gameObject.SetActive(false);
		}

		//Wenn die Zeit abgelaufen ist, Trigger das Event
		if (TimerCounter < 0)
		{
			TimeIsUp.Invoke();
		}
	}

	public void SetMemory(Event ev, GameObject PlayerStats, bool isFinished)
	{
		Playervariables = PlayerStats;

		Memory = ev;

		//Beim NewTimeKeeper an den Tageswechsel dranhängen
		Playervariables.GetComponent<NewTimeKeeper>().NewDay.AddListener(() => { DecreaseTimerCounter(); });

		IsFinished = isFinished;

		//Berechnung, wieviel zeit noch ist bis zum Eventende
		TimerCounter = NewTimeKeeper.BerechneTage(
			Playervariables.GetComponent<NewTimeKeeper>().CurrentDay, 
			Playervariables.GetComponent<NewTimeKeeper>().CurrentMonth, 
			Playervariables.GetComponent<NewTimeKeeper>().CurrentYear, 
			Memory.Event_Tag, Memory.Event_Monat, Memory.Event_Jahr);

		//Herausfinden, welche SpezialEvents hinzugefügt werden muessen
		if (!string.IsNullOrEmpty(Memory.SpecialEvents))
		{
			var x = Memory.SpecialEvents.Split(',');

			foreach (var item in x)
			{
				if (item.Contains("Exponat"))
				{
					gameObject.AddComponent<Exponate_Needed>();
					char[] ExponatChars = { 'E', 'x', 'p', 'o', 'n', 'a', 't', ':' };
					var y = item.TrimStart(ExponatChars);

					gameObject.GetComponent<Exponate_Needed>().HowManyNeeded = int.Parse(y);
				}
				if (item.Contains("Einblenden"))
				{
					char[] EinblendenChars = { 'E', 'i', 'n', 'b', 'l', 'e', 'n', 'd', 'e', 'n', ':' };
					var y = item.TrimStart(EinblendenChars);
					var z = y.Split('.');
					var a = new int[3];

					for (int i = 0; i < z.Length; i++)
					{
						a[i] = int.Parse(z[i]);
					}

					Vorlauf = NewTimeKeeper.BerechneTage(
						a[0], a[1], a[2],
						Memory.Event_Tag, Memory.Event_Monat, Memory.Event_Jahr);
				}
				if (item.Contains("GameOverOption"))
				{
					gameObject.AddComponent<GameOverOption>();
					char[] GameOverChars = { 'G', 'a', 'm', 'e', 'O', 'v', 'e', 'r', 'O', 'p', 't', 'i', 'o', 'n', ':' };
					var y = item.TrimStart(GameOverChars);

					gameObject.GetComponent<GameOverOption>().WhichOptionLoses = int.Parse(y);
				}
			}
		}

		//Wenn kein spezielles Einblenddatum gegeben ist werden 90 Tage verwendet
		if (Vorlauf == 0)
		{
			Vorlauf = 90;
		}

		//Initialisiere den angezeigten Countdown
		Timer.text = "Noch " + TimerCounter.ToString() + " Tage";

		Debug.Log("Vorlauf Event: " + Memory.ID + " = " +  Vorlauf + " , Verbleibende Tage: " + TimerCounter);
	}
	public void SelectOption1()
	{
		SelectedOption1 = true;

		if (SelectedOption2)
		{
			SelectedOption2 = false;
			Option2.image.sprite = SpriteNormal;
		}

		Option1.image.sprite = SpriteSelected; ;
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
	public void ExponateDone()
	{
		SelectedOption1 = true;

		Option1.image.sprite = SpriteSelected;
	}
	private void EventEffect1()
	{
		print("ID: " + Memory.ID + ", EventText: " + Memory.EventText + ", Option: " + SelectedOption1 + SelectedOption2);

		Playervariables.GetComponent<AnsehenScript>().ManipulateAnsehen(Memory.Option1_Ansehen);
		Playervariables.GetComponent<Politikmeter>().ManipulatePolitics(Memory.Option1_Politik);
		Playervariables.GetComponent<Money>().Geld(Memory.Option1_Geld);

		Ticker.NewTick.Invoke(Memory.Option1_EffectTicker);

		IsFinished = true;
		this.gameObject.SetActive(false);
	}
	private void EventEffect2()
	{
		print("ID: " + Memory.ID + ", EventText: " + Memory.EventText + ", Option: " + SelectedOption1 + SelectedOption2);

		Playervariables.GetComponent<AnsehenScript>().ManipulateAnsehen(Memory.Option2_Ansehen);
		Playervariables.GetComponent<Politikmeter>().ManipulatePolitics(Memory.Option2_Politik);
		Playervariables.GetComponent<Money>().Geld(Memory.Option2_Geld);

		Ticker.NewTick.Invoke(Memory.Option2_EffectTicker);

		IsFinished = true;
		this.gameObject.SetActive(false);
	}
	public void TooLate() //To Apologize, wird aufgerufen, wenn man keine Entscheidung trifft
	{
		Playervariables.GetComponent<AnsehenScript>().ManipulateAnsehen(-5);

		Ticker.NewTick.Invoke("Das Event zu verpassen hat dein Ansehen um 5 verschlechtert.");

		Playervariables.GetComponent<Money>().Geld(-5000);

		Ticker.NewTick.Invoke("Durch das verpasste Event hast du 5000 RM verloren.");
	}
	public void DecreaseTimerCounter()
	{
		TimerCounter--;

		//Aktualisiere den angezeigten Countdown
		Timer.text = "Noch " + TimerCounter.ToString() + " Tage";

		if ((TimerCounter <= Vorlauf && TimerCounter > 0) && !IsFinished)
		{
			gameObject.SetActive(true);
		}
	}
	public void TriggerTheEffect() //Wenn die Zeit abgelaufen ist, führe, je nachdem welche Option ausgewaehlt ist, das Event aus
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
		Playervariables.GetComponent<NewTimeKeeper>().NewDay.RemoveListener(() => { DecreaseTimerCounter(); });

		this.gameObject.SetActive(false);
	}
	public static GameObject FindInActiveObjectByName(string name)
	{
		Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
		for (int i = 0; i < objs.Length; i++)
		{
			if (objs[i].hideFlags == HideFlags.None)
			{
				if (objs[i].name == name)
				{
					return objs[i].gameObject;
				}
			}
		}
		return null;
	}
}