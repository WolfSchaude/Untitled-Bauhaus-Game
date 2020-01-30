using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GebäudeÜbersicht : MonoBehaviour
{
    public GameObject PlayerVariables;

    public Text werkstattCount;
    public Text lehrsaalCount;
    public Text wohnheimCount;

    void Start()
    {
    }

    void Update()
    {
        //if (werkstattCount != null) werkstattCount.text = "Gebaute Werkstätte: \n" + PlayerVariables.GetComponent<Bausystem>().StructuresCounter[1].ToString() + " / 7";
        //if (lehrsaalCount != null) lehrsaalCount.text = "Gebaute Lehrsäle: \n" + PlayerVariables.GetComponent<Bausystem>().StructuresCounter[3].ToString() + " / 7";
        //if (wohnheimCount != null) wohnheimCount.text = "Gebaute Wohnheime: \n" + PlayerVariables.GetComponent<Bausystem>().StructuresCounter[2].ToString() + " / 3"; 
    }
}
