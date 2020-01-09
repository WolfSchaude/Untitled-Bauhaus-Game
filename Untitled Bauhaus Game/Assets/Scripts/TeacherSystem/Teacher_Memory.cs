using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teacher_Memory : MonoBehaviour
{
    public GameObject Parent;
    public GameObject Ticker;

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

    public void SetMemory(Teacher teacher, GameObject parent, GameObject ticker)
    {
        Memory = teacher;
        Parent = parent;
        Ticker = ticker;

        Name = Memory.Name;

        Datum_Tag = Memory.SichtbarAb_Tag;
        Datum_Monat = Memory.SichtbarAb_Monat;
        Datum_Jahr = Memory.SichtbarAb_Jahr;

        EventSystem = GameObject.Find("EventSystem");

        GameObject.Find("EventSystem").GetComponent<DatumRelatedEvents>().changedDay.AddListener(() => { DecreaseTimerCounter(); });

        var x = GameObject.Find("Datum").GetComponent<NewTimeKeeper>();

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

		//for (int i = 0; i < TeacherLoader.tb.Buffer.Count; i++)
		//	GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(TeacherLoader.tb.Buffer[i].Einstellungskosten);
		GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(1500);


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

            GameObject.Find("EventSystem").GetComponent<DatumRelatedEvents>().changedDay.RemoveListener(() => { DecreaseTimerCounter(); });
        }
    }
}
