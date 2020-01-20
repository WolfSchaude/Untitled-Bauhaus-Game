using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GebäudeÜbersicht : MonoBehaviour
{
    public Animator OverviewAnimator;

    public GameObject PlayerVariables;

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

        if (werkstattCount != null) werkstattCount.text = "Gebaute Werkstätte: \n" + PlayerVariables.GetComponent<Bausystem>().StructuresCounter[1].ToString() + " / 7";
        if (lehrsaalCount != null) lehrsaalCount.text = "Gebaute Lehrsäle: \n" + PlayerVariables.GetComponent<Bausystem>().StructuresCounter[3].ToString() + " / 7";
        if (wohnheimCount != null) wohnheimCount.text = "Gebaute Wohnheime: \n" + PlayerVariables.GetComponent<Bausystem>().StructuresCounter[2].ToString() + " / 3"; 
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
