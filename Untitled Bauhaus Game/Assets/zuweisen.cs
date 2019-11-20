using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zuweisen : MonoBehaviour
{

    public bool showBewerbungzugewiesen;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Canvas>().enabled = false;
        //GameObject.Find("bild_eingestellter1").GetComponent<Image>().enabled = false;
        //GameObject.Find("eingestellter1_text").GetComponent<Text>().enabled = false;
        //GameObject.Find("bild_eingestellter2").GetComponent<Image>().enabled = false;
        //GameObject.Find("eingestellter2_text").GetComponent<Text>().enabled = false;
        //GameObject.Find("bild_eingestellter3").GetComponent<Image>().enabled = false;
        //GameObject.Find("eingestellter3_text").GetComponent<Text>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("l") && !GameObject.Find("PersonalEinstellen - Canvas").GetComponent<Canvas>().enabled)
        {
            showBewerbungzugewiesen = !showBewerbungzugewiesen;
            if (showBewerbungzugewiesen)
                this.GetComponent<Canvas>().enabled = true;
            else if (!showBewerbungzugewiesen)
                this.GetComponent<Canvas>().enabled = false;
        }
    }
}