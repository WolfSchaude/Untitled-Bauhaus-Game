using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teacher_Memory : MonoBehaviour
{
    public GameObject Parent;
    public GameObject DropdownPrefab;
    public GameObject Ticker;

    public Teacher Memory;

    void Start()
    {
        Memory = new Teacher();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMemory(Teacher teacher, GameObject parent, GameObject dropdown, GameObject ticker)
    {
        Memory = teacher;
        Parent = parent;
        DropdownPrefab = dropdown;
        Ticker = ticker;
    }

    public void StelleEin()
    {
        var x = gameObject;

        x.transform.SetParent(Parent.transform, true);
        x.GetComponentsInChildren<Text>()[2].text = "";
        x.GetComponent<Button>().interactable = false;

        TeacherScript.Eingestellte.Add(x);

        Ticker.GetComponent<FeedbackScript>().NewTick("DU hast den Formmeister " + x.GetComponent<Teacher_Memory>().Memory.Name + " eingestellt.");

        gameObject.SetActive(false);
    }
}
