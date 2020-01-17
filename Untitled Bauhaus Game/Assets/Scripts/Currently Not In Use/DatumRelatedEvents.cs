using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DatumRelatedEvents : MonoBehaviour //Event to check if the day or month has changed
{
    public UnityEvent changedMonth;
    public UnityEvent changedDay;

    public GameObject Timekeeper;

    private int lastMonth;
    private int lastDay;

    void Start()
    {
        lastMonth = Timekeeper.GetComponent<NewTimeKeeper>().CurrentMonth;
        lastDay = Timekeeper.GetComponent<NewTimeKeeper>().CurrentDay;
    }

    void Update()
    {
        checkMonth();
        checkDay();
    }

    public void checkMonth()  //Check if the month has changed
    {
        if (Timekeeper.GetComponent<NewTimeKeeper>().CurrentMonth != lastMonth) 
        {
            changedMonth.Invoke();
            lastMonth = Timekeeper.GetComponent<NewTimeKeeper>().CurrentMonth;
        }
    }

    public void checkDay()  //Check if the day has changed
    {
        if (Timekeeper.GetComponent<NewTimeKeeper>().CurrentDay != lastDay) 
        {
            changedDay.Invoke();
            lastDay = Timekeeper.GetComponent<NewTimeKeeper>().CurrentDay;
        }
    }
}
