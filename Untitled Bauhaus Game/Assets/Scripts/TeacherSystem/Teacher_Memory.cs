using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teacher_Memory : MonoBehaviour
{
    NewTimeKeeper _TimeKeeper;

    public Teacher Memory;

    public int Vorlauf = 1;

    public int TimerCounter = 0;

    public void SetMemory(Teacher teacher, NewTimeKeeper time)
    {
        Memory = teacher;
        _TimeKeeper = time;

        _TimeKeeper.NewDay.AddListener(() => { DecreaseTimerCounter(); });

        TimerCounter = _TimeKeeper.BerechneTageVonJetzt(Memory.SichtbarAb_Tag, Memory.SichtbarAb_Monat, Memory.SichtbarAb_Jahr);

        if (TimerCounter > Vorlauf)
        {
            this.gameObject.SetActive(false);
        }
    }

    void DecreaseTimerCounter()
    {
        TimerCounter--;

        if (TimerCounter <= Vorlauf && TimerCounter > 0)
        {
            gameObject.SetActive(true);

            _TimeKeeper.NewDay.RemoveListener(() => { DecreaseTimerCounter(); });
        }
    }

    public void SetButtonHire()
    {
        gameObject.GetComponentInChildren<Button>().onClick.RemoveAllListeners();
        gameObject.GetComponentInChildren<Button>().onClick.AddListener(() => { TeacherScript.TeacherHired.Invoke(Memory); });
        gameObject.GetComponentsInChildren<Text>()[4].text = "Anheuern";
    }

    public void SetButtonAssign()
    {
        gameObject.GetComponentInChildren<Button>().onClick.RemoveAllListeners();
        gameObject.GetComponentInChildren<Button>().onClick.AddListener(() => { TeacherScript.TeacherAssigned.Invoke(Memory); });
        gameObject.GetComponentsInChildren<Text>()[4].text = "Zuweisen";
    }

    public void SetButtonDeAssign()
    {
        gameObject.GetComponentInChildren<Button>().onClick.RemoveAllListeners();
        gameObject.GetComponentInChildren<Button>().onClick.AddListener(() => { TeacherScript.TeacherDeAssigned.Invoke(Memory); });
        gameObject.GetComponentsInChildren<Text>()[4].text = "Freistellen";
    }
}
