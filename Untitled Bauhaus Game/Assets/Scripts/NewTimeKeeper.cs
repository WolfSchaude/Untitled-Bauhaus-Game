using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NewTimeKeeper : MonoBehaviour
{
    public GameObject FastForwardScriptObject;
    public GameObject SaveGameKeeper;

    public int StartDay = 20;
    public int StartMonth = 11;
    public int StartYear = 1919;

    public int CurrentDay;
    public int CurrentMonth;
    public int CurrentYear;

    public Text Display;

    bool AlreadyRunningCoroutine = false;

    private void Awake()
    {
        CurrentDay = StartDay;
        CurrentMonth = StartMonth;
        CurrentYear = StartYear;
    }
    void Start()
    {
    }

    void FixedUpdate()
    {
        switch (FastForwardScriptObject.GetComponent<FastForward>().Mode)
        {
            case FastForward.TimeMode.Pause:

                //Keine Zeit vergeht

                break;

            case FastForward.TimeMode.Normal:

                if (!AlreadyRunningCoroutine)
                {
                    StartCoroutine(ZweiSekundenEinTag());
                }

                break;

            case FastForward.TimeMode.FastForward:

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
                }
                else
                {
                    CurrentDay++;
                }
                break;
            case 30:
                if (CurrentMonth == 4 || CurrentMonth == 6 || CurrentMonth == 9 || CurrentMonth == 11)
                {
                    CurrentDay = 1;
                    CurrentMonth++;
                }
                else
                {
                    CurrentDay++;
                }
                break;
            case 31:
                CurrentDay = 1;

                if (CurrentMonth == 12)
                {
                    CurrentMonth = 1;
                    CurrentYear++;
                }
                else
                {
                    CurrentMonth++;
                }
                break;
            default:
                CurrentDay++;
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

    public void Save()
    {
        SaveGameKeeper.GetComponent<SaveGameManager>().Savestate.CurrentDay = CurrentDay;
        SaveGameKeeper.GetComponent<SaveGameManager>().Savestate.CurrentMonth = CurrentMonth;
        SaveGameKeeper.GetComponent<SaveGameManager>().Savestate.CurrentYear = CurrentYear;

        SaveGameKeeper.GetComponent<SaveGameManager>().WhoHasSaved[0] = true;
    }

    public void Load(Save save)
    {
        CurrentDay = save.CurrentDay;
        CurrentMonth = save.CurrentMonth;
        CurrentYear = save.CurrentYear;

        //SaveGameKeeper.GetComponent<SaveGameManager>().WhoHasLoaded[0] = true;
    }
}
