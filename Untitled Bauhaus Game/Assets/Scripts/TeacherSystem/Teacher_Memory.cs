using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teacher_Memory : MonoBehaviour
{
    public GameObject Parent;
    public GameObject Ticker;

    public Teacher Memory;

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
    }

    public void StelleEin()
    {
        var x = gameObject;

        x.transform.SetParent(Parent.transform, true);
        x.GetComponentsInChildren<Text>()[2].text = "";
        x.GetComponentsInChildren<Text>()[3].text = "";
        x.GetComponent<Button>().interactable = false;
        x.transform.GetChild(5).gameObject.SetActive(true);

        TeacherScript.Eingestellte.Add(x);

        Ticker.GetComponent<FeedbackScript>().NewTick("Du hast den Formmeister " + Name + " eingestellt.");

        gameObject.SetActive(false);
    }
}
