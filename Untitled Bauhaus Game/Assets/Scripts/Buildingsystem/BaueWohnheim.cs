using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaueWohnheim : MonoBehaviour
{
    public int AnzahlWohnheime = 0;
	public int studKapazitätWohn = 200;
	public int AktPreisW = 1000;

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

    }
    public void NeuesWohnheim()
    {
        switch (AnzahlWohnheime)
        {
            case 0:
                if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreisW)
                {
                    heim1.SetActive(true);
                    AnzahlWohnheime++;
                    GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreisW);
                    GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität += studKapazitätWohn;
                    AktPreisW = AktPreisW * 2;
                }
				break;
            case 1:
                if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreisW)
                {
                    heim2.SetActive(true);
                    AnzahlWohnheime++;
                    GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreisW);
                    GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität += studKapazitätWohn;
                    AktPreisW = AktPreisW * 2;
                }
                break;
            case 2:
                if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreisW)
                {
                    heim3.SetActive(true);
                    AnzahlWohnheime++;
                    GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreisW);
                    GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität += studKapazitätWohn;
                    AktPreisW = int.MaxValue;
                }
                break;
            default:
                break;
        }
    }
}
