﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class NewTickEvent : UnityEvent<string>
{
}

public class Ticker : MonoBehaviour
{
    /// <summary>
    /// Reference to: The TExtbox where the tickers are shown
    /// </summary>
    [SerializeField] Text TextBox;
    /// <summary>
    /// Reference to the TExtbox where the Date is shown, to incorporate it in the message
    /// </summary>
    [SerializeField] Text DatumBox;

    /// <summary>
    /// The Scrollrect used to display the text. Reference needed to scroll it to the bottom
    /// </summary>
    [SerializeField] ScrollRect _ScrollRect;

    /// <summary>
    /// Internal Boolean to make a smooth downscroll;
    /// </summary>
    [SerializeField] bool _IsScrolling;

    /// <summary>
    /// Global Event to let them create New Ticks from everywhere without annoying references
    /// </summary>
    public static NewTickEvent NewTick;

    private void Awake()
    {
        if (NewTick == null)
        {
            NewTick = new NewTickEvent();
        }

        NewTick.AddListener((x) => { AddText(x); });
    }

    void Update()
    {
        if (_IsScrolling)
            _ScrollRect.verticalNormalizedPosition -= Time.deltaTime * 2;
        if (_ScrollRect.verticalNormalizedPosition <= 0)
        {
            _IsScrolling = false;
        }
    }

    /// <summary>
    /// Adds a new Message to the Ticker box. 
    /// </summary>
    /// <param name="message"> message is the string that will be displayed with the current date</param>
    public void AddText(string message)
    {
        TextBox.text = TextBox.text + "\n" + "<color=#ffdd00ff>[" + DatumBox.text + "]</color> \n" + message;
        _IsScrolling = true;
    }
}
