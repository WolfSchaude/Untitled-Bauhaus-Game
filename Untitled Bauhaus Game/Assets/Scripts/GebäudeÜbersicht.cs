﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GebäudeÜbersicht : MonoBehaviour
{
    public GameObject overviewWindow;

    public Text werkstattCount;
    public Text lehrsaalCount;
    public Text wohnheimCount;

    void Start()
    {
        overviewWindow.SetActive(false);   
    }

    void Update()
    {
        werkstattCount.text = "Gebaute Werkstätte: \n" + GameObject.Find("UI").GetComponent<BaueArchitekturwerkstatt>().AnzahlWerkstaette.ToString() + " / 7"; 
        lehrsaalCount.text = "Gebaute Lehrsäle: \n" + GameObject.Find("UI").GetComponent<BaueLehrsaal>().AnzahlLehrsaal.ToString() + " / 8"; 
        wohnheimCount.text = "Gebaute Wohnheime: \n" + GameObject.Find("UI").GetComponent<BaueWohnheim>().AnzahlWohnheime.ToString() + " / 3"; 
    }

    public void showWindow() //Sets overview window active
    {
        if (!overviewWindow.activeSelf)
        {
            overviewWindow.SetActive(true);
        }
        else
        {
            overviewWindow.SetActive(false);
        }
    }
}
