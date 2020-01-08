using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DatumRelatedEvents : MonoBehaviour //Event to check if the day or month has changed
{
    public GameObject Datum;

    public UnityEvent changedMonth;
    public UnityEvent changedDay;

    private int lastMonth;
    private int lastDay;

    void Start()
    {
        lastMonth = Datum.GetComponent<TimeKeeper>().currentMonth;
        lastDay = Datum.GetComponent<TimeKeeper>().currentDay;
    }

    void Update()
    {
        checkMonth();
        checkDay();
    }

    public void checkMonth()  //Check if the month has changed
    {
        if (Datum.GetComponent<TimeKeeper>().currentMonth != lastMonth) 
        {
            changedMonth.Invoke();
            lastMonth = Datum.GetComponent<TimeKeeper>().currentMonth;
        }
    }

    public void checkDay()  //Check if the day has changed
    {
        if (Datum.GetComponent<TimeKeeper>().currentDay != lastDay) 
        {
            changedDay.Invoke();
            lastDay = Datum.GetComponent<TimeKeeper>().currentDay;
        }
    }
}
