using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaueWohnheim : MonoBehaviour
{
    public int AnzahlWohnheime = 0;
    public int AktPreisW = 1000;

    public Text PreisW;

    public GameObject heim1;
    public GameObject heim2;
    public GameObject heim3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PreisW.text = "Wohnheim: " + AktPreisW + " RM";
    }
    public void NeuesWohnheim()
    {
        switch (AnzahlWohnheime)
        {
            case 0:
                heim1.SetActive(true);
                AnzahlWohnheime++;
                GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreisW);
                AktPreisW = AktPreisW * 2;
                break;
            case 1:
                heim2.SetActive(true);
                AnzahlWohnheime++;
                GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreisW);
                AktPreisW = AktPreisW * 2;
                break;
            case 2:
                heim3.SetActive(true);
                AnzahlWohnheime++;
                GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreisW);
                AktPreisW = int.MaxValue;
                break;
            default:
                break;
        }
    }
}
