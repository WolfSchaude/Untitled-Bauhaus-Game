using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Events : MonoBehaviour //Event to check if the month changed
{
    public UnityEvent changedMonth;

    private int lastMonth;

    void Start()
    {
        lastMonth = GameObject.Find("Datum").GetComponent<TimeKeeper>().currentMonth;
    }

    void Update()
    {
        if (GameObject.Find("Datum").GetComponent<TimeKeeper>().currentMonth != lastMonth) //Check if the month has changed
        {
            changedMonth.Invoke();
            lastMonth = GameObject.Find("Datum").GetComponent<TimeKeeper>().currentMonth;
        }
    }
}
