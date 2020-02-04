using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exponate_Needed : MonoBehaviour
{
    public int HowManyNeeded;
    private int HowManyMade;

    InWorldEvent_Memory MasterMemory;

    // Start is called before the first frame update
    void Start()
    {
        MasterMemory = gameObject.GetComponent<InWorldEvent_Memory>();

        Event_Memory.FindInActiveObjectByName("ExponatSlider").GetComponent<Exponate>().exponatDone.AddListener(() => { OneMoreMade(); });
    }

    void OneMoreMade()
    {
        HowManyMade++;

        Ticker.NewTick.Invoke(HowManyMade + " von " + HowManyNeeded + " Exponaten für das Event hergestellt.");

        if (HowManyMade >= HowManyNeeded)
        {
            MasterMemory.OptionSet = InWorldEvent_Memory.Selection.Option1;
        }
    }
}
