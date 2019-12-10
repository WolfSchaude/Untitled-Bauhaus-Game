using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GebäudeÜbersicht : MonoBehaviour
{
    public GameObject overviewWindow;

    public Animator OverviewAnimator;

    public Text werkstattCount;
    public Text lehrsaalCount;
    public Text wohnheimCount;

    public bool Collapsed;

    void Start()
    {
        Collapsed = false;
    }

    void Update()
    {
        werkstattCount.text = "Gebaute Werkstätte: \n" + GameObject.Find("UI").GetComponent<BaueArchitekturwerkstatt>().AnzahlWerkstaette.ToString() + " / 7"; 
        lehrsaalCount.text = "Gebaute Lehrsäle: \n" + GameObject.Find("UI").GetComponent<BaueLehrsaal>().AnzahlLehrsaal.ToString() + " / 8"; 
        wohnheimCount.text = "Gebaute Wohnheime: \n" + GameObject.Find("UI").GetComponent<BaueWohnheim>().AnzahlWohnheime.ToString() + " / 3"; 
    }

    public void showWindow() //Sets overview window active
    {
        OverviewAnimator.SetTrigger("Click");

        Collapsed = !Collapsed;
    }

    public void CloseOverview()
    {
        if (!Collapsed)
        {
            OverviewAnimator.SetTrigger("Click");

            Collapsed = !Collapsed;
        }
    }
}
