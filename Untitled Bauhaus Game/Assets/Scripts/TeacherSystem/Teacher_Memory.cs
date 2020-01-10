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

    void Start()
    {
    }
    void Update()
    {
    }

    public void SetMemory(Teacher teacher, GameObject parent, GameObject ticker, GameObject PlayerStats)
    {
        Memory = teacher;
        Parent = parent;
        Ticker = ticker;
        Playervariables = PlayerStats;

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
        var x = gameObject;

		Playervariables.GetComponent<Money>().Bezahlen(1500);


		x.transform.SetParent(Parent.transform, true);
        x.GetComponentsInChildren<Text>()[2].text = "";
        x.GetComponentsInChildren<Text>()[3].text = "";
        x.GetComponent<Button>().interactable = false;
        x.transform.GetChild(5).gameObject.SetActive(true);

        TeacherScript.Eingestellte.Add(x);

        EventSystem.GetComponent<TeacherLoader>().HiredTeachers.Find(i => i.Name == Name).Hired = true;

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
