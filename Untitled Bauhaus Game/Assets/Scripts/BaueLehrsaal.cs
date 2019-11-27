using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaueLehrsaal : MonoBehaviour
{
    int AnzahlLehrsaal = 0;
    int AktPreisL = 1000;

    public Text PreisL;

    public GameObject lehr1;
    public GameObject lehr2;
    public GameObject lehr3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PreisL.text = "Lehrsaal: " + AktPreisL + " DM";
    }
    public void NeuerLehrsaal()
    {
        switch (AnzahlLehrsaal)
        {
            case 0:
                lehr1.SetActive(true);
                AnzahlLehrsaal++;
                GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(1000);
                AktPreisL = AktPreisL * 2;
                break;
            case 1:
                lehr2.SetActive(true);
                AnzahlLehrsaal++;
                GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(2000);
                AktPreisL = AktPreisL * 2;
                break;
            case 2:
                lehr3.SetActive(true);
                AnzahlLehrsaal++;
                GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(4000);
                AktPreisL = 1000000000;
                break;
            case 3:
                break;
            default:
                break;
        }
    }
}
