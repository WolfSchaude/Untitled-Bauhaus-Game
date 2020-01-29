using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teacher_Memory : MonoBehaviour
{
    public GameObject Parent;
    public GameObject Ticker;
    public GameObject Playervariables;
    public GameObject EventSystem;

    public Teacher Memory;

	public int Kosten;

    public int Vorlauf = 1;

    public int Datum_Tag = 0;
    public int Datum_Monat = 0;
    public int Datum_Jahr = 0;

    public int TimerCounter = 0;

    string Name;

    private TeacherScript TeacherScriptObject;

    public void SetMemory(Teacher teacher, GameObject parent, GameObject ticker, GameObject PlayerStats, TeacherScript script)
    {
        Memory = teacher;
        Parent = parent;
        Ticker = ticker;
        Playervariables = PlayerStats;
        TeacherScriptObject = script;

        Name = Memory.Name;

        Datum_Tag = Memory.SichtbarAb_Tag;
        Datum_Monat = Memory.SichtbarAb_Monat;
        Datum_Jahr = Memory.SichtbarAb_Jahr;

        EventSystem = GameObject.Find("EventSystem");

        Playervariables.GetComponent<NewTimeKeeper>().NewDay.AddListener(() => { DecreaseTimerCounter(); });

        var x = Playervariables.GetComponent<NewTimeKeeper>();

        var TagBuffer = x.CurrentDay;
        var MonatBuffer = x.CurrentMonth;
        var JahrBuffer = x.CurrentYear;

        TimerCounter = NewTimeKeeper.BerechneTage(TagBuffer, MonatBuffer, JahrBuffer, Datum_Tag, Datum_Monat, Datum_Jahr);

        if (TimerCounter > Vorlauf)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void StelleEin()
    {
        TeacherScriptObject.DeleteSample();

        Memory.Hired = true;

        TeacherScript._Teachers_Hired.Add(Memory);
        TeacherScriptObject.Teachers_Hired_Old.Add(TeacherScriptObject.NewTeacher(Memory));

		Playervariables.GetComponent<Money>().Bezahlen(Memory.Einstellungskosten);

        Ticker.GetComponent<FeedbackScript>().NewTick("Du hast den Formmeister " + Name + " eingestellt.");

        gameObject.SetActive(false);
    }

    public void DecreaseTimerCounter()
    {
        TimerCounter--;

        if (TimerCounter <= Vorlauf && TimerCounter > 0)
        {
            gameObject.SetActive(true);

            Playervariables.GetComponent<NewTimeKeeper>().NewDay.RemoveListener(() => { DecreaseTimerCounter(); });
        }
    }
}
