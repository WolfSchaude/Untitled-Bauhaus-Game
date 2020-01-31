using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class NewTimeKeeper : MonoBehaviour, ISaveableInterface
{
    public GameObject SaveGameKeeper;

    //---------------------( General Time / Date Stuff )---------------------//

    public UnityEvent NewDay;
    public UnityEvent NewMonth;
    public UnityEvent NewYear;

    public int StartDay { get; private set; } = 20;
    public int StartMonth { get; private set; } = 11;
    public int StartYear { get; private set; } = 1919;

    public int CurrentDay { get; private set; }
    public int CurrentMonth { get; private set; }
    public int CurrentYear { get; private set; }

    public Text Display;

    /// <summary>
    /// Necessary to prevent running multiple Coroutines for adding a Day
    /// </summary>
    bool AlreadyRunningCoroutine = false;


    //------------------------( Fast Forward Stuff )------------------------//
    /// <summary>
    /// Reference to the WeatherController to be able to Stop the Sun Movement
    /// </summary>
    [SerializeField] private ToD_Base WeatherController;
    /// <summary>
    /// Enum to switch between the three states which the times system knows and uses
    /// </summary>
    public TimeMode Mode;

    TimeMode ModeBuffer;

    /// <summary>
    /// The Sprite that is applied to the buttons when not selected
    /// </summary>
    [SerializeField] Sprite Normal;
    /// <summary>
    /// The Sprite that is applied to the buttons when selected
    /// </summary>
    [SerializeField] Sprite Selected;

    /// <summary>
    /// The Image that changes, when the corresponging Button (Pause) is pressed
    /// </summary>
    [SerializeField] Image ButtonPause;
    /// <summary>
    /// The Image that changes, when the corresponging Button (Normal) is pressed
    /// </summary>
    [SerializeField] Image ButtonNormal;
    /// <summary>
    /// The Image that changes, when the corresponging Button (FastForward) is pressed
    /// </summary>
    [SerializeField] Image ButtonFastForward;

    /// <summary>
    /// Enum for managing the different TimeModes
    /// </summary>
    public enum TimeMode
    {
        Pause, Normal, FastForward
    }

    void Start()
    {
        //Start replaced by LoadStart triggered by SaveGameManager
    }

    void FixedUpdate()
    {
        switch (Mode)
        {
            case TimeMode.Pause:

                //Keine Zeit vergeht

                break;

            case TimeMode.Normal:

                if (!AlreadyRunningCoroutine)
                {
                    StartCoroutine(ZweiSekundenEinTag());
                }

                break;

            case TimeMode.FastForward:

                if (!AlreadyRunningCoroutine)
                {
                    StartCoroutine(HalbeSekundeEinTag());
                }

                break;

            default:
                break;
        }

        Display.text = CurrentDay + "." + CurrentMonth + "." + CurrentYear;
    }
    void Update()
    {
        
    }

    private void AddDay()
    {
        switch (CurrentDay)
        {
            case 28:
                if (CurrentMonth == 2)
                {
                    CurrentDay = 1;
                    CurrentMonth++;
                    NewMonth.Invoke();
                }
                else
                {
                    CurrentDay++;
                }

                NewDay.Invoke();

                break;
            case 30:
                if (CurrentMonth == 4 || CurrentMonth == 6 || CurrentMonth == 9 || CurrentMonth == 11)
                {
                    CurrentDay = 1;
                    CurrentMonth++;
                    NewMonth.Invoke();
                }
                else
                {
                    CurrentDay++;
                }

                NewDay.Invoke();

                break;
            case 31:
                CurrentDay = 1;

                if (CurrentMonth == 12)
                {
                    CurrentMonth = 1;
                    CurrentYear++;
                    NewYear.Invoke();
                }
                else
                {
                    CurrentMonth++;
                }

                NewMonth.Invoke();
                NewDay.Invoke();

                break;
            default:
                CurrentDay++;

                NewDay.Invoke();
                break;
        }
    }

    IEnumerator ZweiSekundenEinTag()
    {
        AlreadyRunningCoroutine = true;

        yield return new WaitForSeconds(2);

        AddDay();

        AlreadyRunningCoroutine = false;
    }

    IEnumerator HalbeSekundeEinTag()
    {
        AlreadyRunningCoroutine = true;

        yield return new WaitForSeconds(0.5f);

        AddDay();

        AlreadyRunningCoroutine = false;
    }

    public static int BerechneTage(int StartTag, int StartMonat, int StartJahr, int Endtag, int EndMonat, int EndJahr)
    {
        DateTime Start = new DateTime(StartJahr, StartMonat, StartTag);
        DateTime Ende = new DateTime(EndJahr, EndMonat, Endtag);

        return (Ende - Start).Days;
    }

    public int BerechneTageVonJetzt(int EndTag, int Endmonat, int EndJahr)
    {
        DateTime Start = new DateTime(CurrentYear, CurrentMonth, CurrentDay);
        DateTime Ende = new DateTime(EndJahr, Endmonat, EndTag);

        return (Ende - Start).Days;
    }

	#region Here are the functions to change the speed of time

	/// <summary>
	/// Sets the TimeMode to Paused. Causes no longer counting new days, stopping exponat and Buildung progress e.g.
	/// </summary>
	public void SetPause()
    {
        WeatherController.Pause = true;

        Mode = TimeMode.Pause;

        ButtonPause.sprite = Selected;
        ButtonNormal.sprite = Normal;
        ButtonFastForward.sprite = Normal;
    }

    /// <summary>
    /// Sets the TimeMode to Normal, causing normal flow of time with one day lasting two seconds
    /// </summary>
    public void SetNormal()
    {
        WeatherController.Pause = false;

        Mode = TimeMode.Normal;
        ModeBuffer = TimeMode.Normal;

        ButtonPause.sprite = Normal;
        ButtonNormal.sprite = Selected;
        ButtonFastForward.sprite = Normal;
    }

    /// <summary>
    /// Sets the TimeMode to FastForward, causing accelerated flow of time with one day lasting half a second
    /// </summary>
    public void SetFastforward()
    {
        WeatherController.Pause = false;

        Mode = TimeMode.FastForward;
        ModeBuffer = TimeMode.FastForward;

        ButtonPause.sprite = Normal;
        ButtonNormal.sprite = Normal;
        ButtonFastForward.sprite = Selected;
    }

    /// <summary>
    /// Cycles through TimeModes, Pause --> Normal --> Fast --> Pause
    /// </summary>
    public void CycleTimeModes()
    {
        switch (Mode)
        {
            case TimeMode.Pause: SetNormal(); break;
            case TimeMode.Normal: SetFastforward(); break;
            case TimeMode.FastForward: SetPause(); break;
            default: break;
        }
    }

    /// <summary>
    /// Saves the current Mode and Pauses, if called again resumes to previously saved Mode
    /// </summary>
    public void PauseAndReturn()
    {
        if (Mode != TimeMode.Pause)
        {
            ModeBuffer = Mode;

            SetPause();
        }
        else
        {
            Mode = ModeBuffer;
        }
    }

    #endregion
    public void Save()
    {
        SaveGameKeeper.GetComponent<SaveGameManager>().Savestate.CurrentDay = CurrentDay;
        SaveGameKeeper.GetComponent<SaveGameManager>().Savestate.CurrentMonth = CurrentMonth;
        SaveGameKeeper.GetComponent<SaveGameManager>().Savestate.CurrentYear = CurrentYear;
        SaveGameKeeper.GetComponent<SaveGameManager>().Savestate.CurrentMode = Mode;

        SaveGameKeeper.GetComponent<SaveGameManager>().WhoHasSaved[0] = true;
    }

    public void Load(Save save)
    {
        CurrentDay = save.CurrentDay;
        CurrentMonth = save.CurrentMonth;
        CurrentYear = save.CurrentYear;
        Mode = save.CurrentMode;
    }

    public void LoadStart()
    {
        CurrentDay = StartDay;
        CurrentMonth = StartMonth;
        CurrentYear = StartYear;

        SetPause();
    }
}
