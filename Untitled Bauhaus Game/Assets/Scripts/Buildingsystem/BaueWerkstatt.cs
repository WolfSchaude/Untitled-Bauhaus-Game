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
    public GameObject werk4;
    public GameObject werk5;
    public GameObject werk6;
    public GameObject werk7;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Preis.text = "Werkstatt: " + AktPreis + " RM";
    }


    public void NeueWerkstatt()
    {
        switch (AnzahlWerkstaette)
        {
            case 0:
                werk1.SetActive(true);
                AnzahlWerkstaette++;
                GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreis);
                AktPreis = AktPreis * 2;
                break;
            case 1:
                werk2.SetActive(true);
                AnzahlWerkstaette++;
                GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreis);
                AktPreis = AktPreis * 2;
                break;
            case 2:
                werk3.SetActive(true);
                AnzahlWerkstaette++;
                GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreis);
                AktPreis = AktPreis * 2;
                break;
            case 3:
                werk4.SetActive(true);
                AnzahlWerkstaette++;
                GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreis);
                AktPreis = AktPreis * 2;
                break;
            case 4:
                werk5.SetActive(true);
                AnzahlWerkstaette++;
                GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreis);
                AktPreis = AktPreis * 2;
                break;
            case 5:
                werk6.SetActive(true);
                AnzahlWerkstaette++;
                GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreis);
                AktPreis = AktPreis * 2;
                break;
            case 6:
                werk7.SetActive(true);
                AnzahlWerkstaette++;
                GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreis);
                AktPreis = int.MaxValue;
                break;
            default:
                break;
        }
    }
}
