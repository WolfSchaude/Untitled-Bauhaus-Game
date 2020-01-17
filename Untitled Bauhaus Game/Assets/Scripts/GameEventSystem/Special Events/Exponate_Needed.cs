using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exponate_Needed : MonoBehaviour
{
    public int HowManyNeeded;
    private int HowManyMade;

    Event_Memory MasterMemory;

    // Start is called before the first frame update
    void Start()
    {
        MasterMemory = gameObject.GetComponent<Event_Memory>();

        Event_Memory.FindInActiveObjectByName("ExponatSlider").GetComponent<Exponate>().exponatDone.AddListener(() => { OneMoreMade(); });

        gameObject.GetComponentsInChildren<Button>()[0].interactable = false;
        gameObject.GetComponentsInChildren<Button>()[1].gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponentsInChildren<Button>()[0].GetComponentInChildren<Text>().text = HowManyMade + " von " + HowManyNeeded + " Exponaten hergestellt.";

        if (HowManyMade >= HowManyNeeded)
        {
            MasterMemory.ExponateDone();
        }
    }

    void OneMoreMade()
    {
        HowManyMade++;
    }
}
