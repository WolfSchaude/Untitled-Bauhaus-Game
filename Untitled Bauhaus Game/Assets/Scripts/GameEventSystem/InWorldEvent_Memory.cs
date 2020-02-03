using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class MemorySave
{
    public int EventID;

    public InWorldEvent_Memory.Selection Selection;

    public MemorySave(int eventID, InWorldEvent_Memory.Selection selection)
    {
        EventID = eventID;
        Selection = selection;
    }
}

public class InWorldEvent_Memory : MonoBehaviour
{
    /// <summary>
    /// All the Data of an Event in a corresponding class instance
    /// </summary>
    public Event Memory { get; private set; }

    /// <summary>
    /// Counts how Many Days are still left
    /// </summary>
    public int DaysLeft { get; private set; }
    /// <summary>
    /// The how many Days are left from Starting Date
    /// </summary>
    [SerializeField] int DaysLeftFromStart;

    /// <summary>
    /// Enum to Save which option is enabled
    /// </summary>
    public enum Selection
    {
        Option1, Option2, Nothing
    }
    /// <summary>
    /// Instance of Selection, Saves Selection Status of Event Options
    /// </summary>
    public Selection OptionSet { get; private set; } = Selection.Nothing;

    /// <Summary>
    /// Dieses Event wird genutzt um verschiedenen Spezialevents das ablaufen der Zeit mitzuteilen
    /// </Summary>
    public UnityEvent TimeIsUp;

    /// <summary>
    /// Reference to: PlayerVariables, used to make the Events effects possible
    /// </summary>
    [SerializeField] GameObject _Playervariables;

    /// <summary>
    /// The Circle which should get filled more and more as the Time passes
    /// </summary>
    [SerializeField] Image _Image_Circle;

    /// <summary>
    /// Animationstarter to Open the menu Window
    /// </summary>
    [SerializeField] AnimationStarter AnimStarter;

    [SerializeField] float ImagePercentage;

    private void Awake()
    {
        if (TimeIsUp == null)
        {
            TimeIsUp = new UnityEvent();
        }
        TimeIsUp.AddListener((() => { TriggerTheEffect(); }));

        _Image_Circle = gameObject.GetComponentInChildren<Image>();
    }

    void Update()
    {
        if (DaysLeft == 0)
        {
            TimeIsUp.Invoke();
            TimeIsUp.RemoveAllListeners();
        }
        ImagePercentage = DaysLeft / (float)DaysLeftFromStart;
        _Image_Circle.fillAmount = ImagePercentage;
    }

	#region Functions for Event Effects
	private void TriggerTheEffect()
    {
        switch (OptionSet)
        {
            case Selection.Option1: EventEffect1(); break;
            case Selection.Option2: EventEffect2(); break;
            case Selection.Nothing: TooLate(); break;
            default: break;
        }
    }

    private void EventEffect1()
    {
        _Playervariables.GetComponent<AnsehenScript>().ManipulateAnsehen(Memory.Option1_Ansehen);
        _Playervariables.GetComponent<Politikmeter>().ManipulatePolitics(Memory.Option1_Politik);
        _Playervariables.GetComponent<Money>().Geld(Memory.Option1_Geld);

        Ticker.NewTick.Invoke(Memory.Option1_EffectTicker);
    }

    private void EventEffect2()
    {
        _Playervariables.GetComponent<AnsehenScript>().ManipulateAnsehen(Memory.Option2_Ansehen);
        _Playervariables.GetComponent<Politikmeter>().ManipulatePolitics(Memory.Option2_Politik);
        _Playervariables.GetComponent<Money>().Geld(Memory.Option2_Geld);

        Ticker.NewTick.Invoke(Memory.Option2_EffectTicker);
    }

    private void TooLate()
    {
        print("Called TooLate");

        _Playervariables.GetComponent<AnsehenScript>().ManipulateAnsehen(-5);

        Ticker.NewTick.Invoke("Das Event zu verpassen hat dein Ansehen um 5 verschlechtert.");

        _Playervariables.GetComponent<Money>().Geld(-5000);

        Ticker.NewTick.Invoke("Durch das verpasste Event hast du 5000 RM verloren.");
    }
	#endregion


	private void OnMouseDown()
    {
        InWorldEvent._InWorldClickEvent.Invoke(Memory);

        AnimStarter.OpenMenu();
    }

    public void SetValues(Event ev, AnimationStarter animationStarter, GameObject PlayerStats)
    {
        Memory = ev;
        AnimStarter = animationStarter;
        _Playervariables = PlayerStats;

        //Beim NewTimeKeeper an den Tageswechsel dranhängen
        _Playervariables.GetComponent<NewTimeKeeper>().NewDay.AddListener(() => { DecreaseTimerCounter(); });

        //Restliche Zeit berechnen
        DaysLeft = NewTimeKeeper.BerechneTage(
            _Playervariables.GetComponent<NewTimeKeeper>().CurrentDay,
            _Playervariables.GetComponent<NewTimeKeeper>().CurrentMonth,
            _Playervariables.GetComponent<NewTimeKeeper>().CurrentYear,
            Memory.Event_Tag, Memory.Event_Monat, Memory.Event_Jahr);

        DaysLeftFromStart = DaysLeft;

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
                if (item.Contains("GameOverOption"))
                {
                    gameObject.AddComponent<GameOverOption>();
                    char[] GameOverChars = { 'G', 'a', 'm', 'e', 'O', 'v', 'e', 'r', 'O', 'p', 't', 'i', 'o', 'n', ':' };
                    var y = item.TrimStart(GameOverChars);

                    gameObject.GetComponent<GameOverOption>().WhichOptionLoses = int.Parse(y);
                }
            }
        }
    }

    private void DecreaseTimerCounter()
    {
        DaysLeft--;
    }

    public void EventLoad(MemorySave memorySave)
    {
        OptionSet = memorySave.Selection;
    }

    public MemorySave EventSave()
    {
        MemorySave x = new MemorySave(Memory.ID, OptionSet);

        return x;
    }
}
