﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GebäudeÜbersicht : MonoBehaviour
{
    public Animator OverviewAnimator;

    public Text werkstattCount;
    public Text lehrsaalCount;
    public Text wohnheimCount;

    public bool Collapsed;

    void Start()
    {
        Collapsed = true;
    }

    void Update()
    {
        OverviewAnimator.SetBool("Bool", Collapsed);

        if (werkstattCount != null) werkstattCount.text = "Gebaute Werkstätte: \n" + GameObject.Find("UI").GetComponent<BaueArchitekturwerkstatt>().AnzahlWerkstaette.ToString() + " / 7";
        if (lehrsaalCount != null) lehrsaalCount.text = "Gebaute Lehrsäle: \n" + GameObject.Find("UI").GetComponent<BaueLehrsaal>().AnzahlLehrsaal.ToString() + " / 8";
        if ( wohnheimCount != null) wohnheimCount.text = "Gebaute Wohnheime: \n" + GameObject.Find("UI").GetComponent<BaueWohnheim>().AnzahlWohnheime.ToString() + " / 3"; 
    }

    public void ToggleOpened() //Sets overview window active
    {
        //OverviewAnimator.SetTrigger("Click");

        Collapsed = !Collapsed;
    }

    public void CloseOverview()
    {
        //if (!Collapsed)
        //{
        //    OverviewAnimator.SetTrigger("Click");

            Collapsed = true;
        //}
    }
}
