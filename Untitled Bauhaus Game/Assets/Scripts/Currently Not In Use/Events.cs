using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Events : MonoBehaviour //Event to check if the day or month has changed
{
    public UnityEvent changedMonth;
    public UnityEvent changedDay;

    private int lastMonth;
    private int lastDay;

    void Start()
    {
        lastMonth = GameObject.Find("Datum").GetComponent<NewTimeKeeper>().CurrentMonth;
        lastDay = GameObject.Find("Datum").GetComponent<NewTimeKeeper>().CurrentDay;
    }

    void Update()
    {
        checkMonth();
        checkDay();
    }

    public void checkMonth()  //Check if the month has changed
    {
        if (GameObject.Find("Datum").GetComponent<NewTimeKeeper>().CurrentMonth != lastMonth) 
        {
            changedMonth.Invoke();
            lastMonth = GameObject.Find("Datum").GetComponent<NewTimeKeeper>().CurrentMonth;
        }
    }

    public void checkDay()  //Check if the day has changed
    {
        if (GameObject.Find("Datum").GetComponent<NewTimeKeeper>().CurrentDay != lastDay) 
        {
            changedDay.Invoke();
            lastDay = GameObject.Find("Datum").GetComponent<NewTimeKeeper>().CurrentDay;
        }
    }
}
