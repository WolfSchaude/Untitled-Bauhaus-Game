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

    string Name;

    void Start()
    {
        Memory = new Teacher();
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

        EventSystem = GameObject.Find("EventSystem");
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


}
