using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaueWerkstatt : MonoBehaviour
{
    public int AnzahlWerkstaette = 0;
	public int studKapazitätWerk = 200;
	public int AktPreis = 1000;

    public float MinQualität;
    public float MaxQualitaet;
    private float Qualität;

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
        MaxQualitaet = 1.5f;
        MinQualität = 0.5f + (AnzahlWerkstaette * 0.05f);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void NeueWerkstatt()
    {
        switch (AnzahlWerkstaette)
        {
            case 0:
                if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreis)
                {
                    Qualität = Random.Range(0.5f + (AnzahlWerkstaette * 0.05f), 1.5f);
                    werk1.SetActive(true);
                    AnzahlWerkstaette++;
                    GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreis);
                    GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität += (int)((float)studKapazitätWerk * (float)Qualität);
                    AktPreis = AktPreis * 2;
                    MinQualität = 0.5f + (AnzahlWerkstaette * 0.05f);
                }
                break;
            case 1:
                if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreis)
                {
                    Qualität = Random.Range(0.5f + (AnzahlWerkstaette * 0.05f), 1.5f);
                    werk2.SetActive(true);
                    AnzahlWerkstaette++;
                    GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreis);
                    GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität += studKapazitätWerk;
                    GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität += (int)((float)studKapazitätWerk * (float)Qualität);
                    AktPreis = AktPreis * 2;
                    MinQualität = 0.5f + (AnzahlWerkstaette * 0.05f);
                }
                break;
            case 2:
                if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreis)
                {
                    Qualität = Random.Range(0.5f + (AnzahlWerkstaette * 0.05f), 1.5f);
                    werk3.SetActive(true);
                    AnzahlWerkstaette++;
                    GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreis);
                    GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität += studKapazitätWerk;
                    GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität += (int)((float)studKapazitätWerk * (float)Qualität);
                    AktPreis = AktPreis * 2;
                    MinQualität = 0.5f + (AnzahlWerkstaette * 0.05f);
                }
                break;
            case 3:
                if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreis)
                {
                    Qualität = Random.Range(0.5f + (AnzahlWerkstaette * 0.05f), 1.5f);
                    werk4.SetActive(true);
                    AnzahlWerkstaette++;
                    GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreis);
                    GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität += studKapazitätWerk;
                    GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität += (int)((float)studKapazitätWerk * (float)Qualität);
                    AktPreis = AktPreis * 2;
                    MinQualität = 0.5f + (AnzahlWerkstaette * 0.05f);
                }
                break;
            case 4:
                if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreis)
                {
                    Qualität = Random.Range(0.5f + (AnzahlWerkstaette * 0.05f), 1.5f);
                    werk5.SetActive(true);
                    AnzahlWerkstaette++;
                    GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreis);
                    GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität += studKapazitätWerk;
                    GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität += (int)((float)studKapazitätWerk * (float)Qualität);
                    AktPreis = AktPreis * 2;
                    MinQualität = 0.5f + (AnzahlWerkstaette * 0.05f);
                }
                break;
            case 5:
                if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreis)
                {
                    Qualität = Random.Range(0.5f + (AnzahlWerkstaette * 0.05f), 1.5f);
                    werk6.SetActive(true);
                    AnzahlWerkstaette++;
                    GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreis);
                    GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität += studKapazitätWerk;
                    GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität += (int)((float)studKapazitätWerk * (float)Qualität);
                    AktPreis = AktPreis * 2;
                    MinQualität = 0.5f + (AnzahlWerkstaette * 0.05f);
                }
                break;
            case 6:
                if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreis)
                {
                    Qualität = Random.Range(0.5f + (AnzahlWerkstaette * 0.05f), 1.5f);
                    werk7.SetActive(true);
                    AnzahlWerkstaette++;
                    GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreis);
                    GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität += studKapazitätWerk;
                    GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität += (int)((float)studKapazitätWerk * (float)Qualität);
                    AktPreis = int.MaxValue;
                }
                break;
            default:
                break;
        }
    }
}
