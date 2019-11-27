using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaueWerkstatt : MonoBehaviour
{
    int AnzahlWerkstaette = 0;
    int AktPreis = 1000;

    public Text Preis;

    public GameObject werk1;
    public GameObject werk2;
    public GameObject werk3;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Preis.text = "Werkstatt: " + AktPreis + " DM";
    }


    public void NeueWerkstatt()
    {
        switch (AnzahlWerkstaette)
        {
            case 0:
                werk1.SetActive(true);
                AnzahlWerkstaette++;
                GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(1000);
                AktPreis = 2000;
                break;
            case 1:
                werk2.SetActive(true);
                AnzahlWerkstaette++;
                GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(2000);
                AktPreis = 4000;
                break;
            case 2:
                werk3.SetActive(true);
                AnzahlWerkstaette++;
                GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(4000);
                AktPreis =  1000000000;
                break;
            case 3:
                break;
            default:
                break;
        }
    }
}
