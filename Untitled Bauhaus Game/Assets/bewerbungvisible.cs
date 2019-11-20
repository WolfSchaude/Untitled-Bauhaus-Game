using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class bewerbungvisible : MonoBehaviour
{

    public bool showBewerbung;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("k") && !GameObject.Find("PersonalZuweisen - Canvas").GetComponent<Canvas>().enabled)
        {
            showBewerbung = !showBewerbung;
            if (showBewerbung)
                this.GetComponent<Canvas>().enabled = true;
            else if (!showBewerbung)
                this.GetComponent<Canvas>().enabled = false;
        }
    }
}
