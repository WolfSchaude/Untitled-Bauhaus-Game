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

    public void StelleEin()
    {
        TeacherScript.TeacherHired.Invoke(Memory);
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
}
