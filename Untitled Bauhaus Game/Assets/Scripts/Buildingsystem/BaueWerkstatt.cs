using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaueWerkstatt : MonoBehaviour
{
    public int AnzahlWerkstaette = 0;
	public int studKapazitätWerk = 200;
	public int AktPreis = 1000;
    public int werkBuildTimeInMonths = 2;

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

    public Werkstatt Script1;
    public Werkstatt Script2;
    public Werkstatt Script3;
    public Werkstatt Script4;
    public Werkstatt Script5;
    public Werkstatt Script6;
    public Werkstatt Script7;

    public int WerkstattTyp;

    public bool buildInProgress = false;

    void Start()
    {
        MaxQualitaet = 1.5f;
        MinQualität = 0.5f + (AnzahlWerkstaette * 0.05f);
        WerkstattTyp = 0;
    }

    void Update()
    {
        buildStructure();
    }

    public void checkMonth() //Wird bei Monatswechsel ausgeführt
    {
        if (buildInProgress)
        {
            werkBuildTimeInMonths--;
        }
    }

    public void buildStructure() //Baut die Struktur, nachdem die Bauzeit abgelaufen ist.
    {
        if (buildInProgress && werkBuildTimeInMonths == 0)
        {
            if (werk6.activeSelf)
            {
                Debug.Log("Lol1");
                werk7.SetActive(true);
                werk7.GetComponent<Werkstatt>().SetType(WerkstattTyp);
            }
            if (werk5.activeSelf)
            {
                Debug.Log("LOL2");
                werk6.SetActive(true);
                werk6.GetComponent<Werkstatt>().SetType(WerkstattTyp);
            }
            if (werk4.activeSelf)
            {
                werk5.SetActive(true);
                werk5.GetComponent<Werkstatt>().SetType(WerkstattTyp);
            }
            if (werk3.activeSelf)
            {
                werk4.SetActive(true);
                werk4.GetComponent<Werkstatt>().SetType(WerkstattTyp);
            }
            if (werk2.activeSelf)
            {
                werk3.SetActive(true);
                werk3.GetComponent<Werkstatt>().SetType(WerkstattTyp);
            }
            if (werk1.activeSelf)
            {
                werk2.SetActive(true);
                Script2.DebugWST = WerkstattTyp;
            }
            werk1.SetActive(true);
            Script1.DebugWST = WerkstattTyp;
            Debug.Log(Script1.DebugWST);

            if (werk2.activeSelf) //wird erst ab werk2 ausgeführt
            {
                GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität += studKapazitätWerk;
            }
            GameObject.Find("EventSystem").GetComponent<StudentenKapazitaet>().studKapazität += (int)((float)studKapazitätWerk * (float)Qualität);
            MinQualität = 0.5f + (AnzahlWerkstaette * 0.05f);

            AnzahlWerkstaette++;
            werkBuildTimeInMonths = 2;
            buildInProgress = false;
        }
    }

    public void SetType()
    {
        WerkstattTyp = GameObject.Find("EventSystem").GetComponent<BaumenuDetail>().buttonCount;
    }

    public void NeueWerkstatt()
    {
        //int Typ = 0;
        if (!buildInProgress)
        {
            switch (AnzahlWerkstaette)
            {
                case 0:
                    if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreis)
                    {
                        GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreis);
                        werk1.transform.position = new Vector3(-2.5f, 3.15f, -6.25f);
                        werk1.transform.localScale = new Vector3(3.5f, 5f, 6.5f);
                        Qualität = Random.Range(0.5f + (AnzahlWerkstaette * 0.05f), 1.5f);
                        buildInProgress = true;
                        //werk1.SetActive(true);
                        //AnzahlWerkstaette++;
                        AktPreis = AktPreis * 2;
                    }
                    break;
                case 1:
                    if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreis)
                    {
                        GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreis);
                        werk2.transform.position = new Vector3(-7.25f, 3.15f, -4.5f);
                        werk2.transform.localScale = new Vector3(6f, 5f, 3.5f);
                        Qualität = Random.Range(0.5f + (AnzahlWerkstaette * 0.05f), 1.5f);
                        buildInProgress = true;
                        //werk2.SetActive(true);
                        //AnzahlWerkstaette++;
                        AktPreis = AktPreis * 2;

                    }
                    break;
                case 2:
                    if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreis)
                    {
                        GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreis);
                        werk3.transform.position = new Vector3(-7.25f, 3.15f, -8.125f);
                        werk3.transform.localScale = new Vector3(6f, 5f, 3.75f);
                        Qualität = Random.Range(0.5f + (AnzahlWerkstaette * 0.05f), 1.5f);
                        buildInProgress = true;
                        //werk3.SetActive(true);
                        //AnzahlWerkstaette++;
                        AktPreis = AktPreis * 2;
                    }
                    break;
                case 3:
                    if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreis)
                    {
                        GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreis);
                        werk4.transform.position = new Vector3(-7.25f, 3.15f, -11.75f);
                        werk4.transform.localScale = new Vector3(6f, 5f, 3.5f);
                        Qualität = Random.Range(0.5f + (AnzahlWerkstaette * 0.05f), 1.5f);
                        buildInProgress = true;
                        //werk4.SetActive(true);
                        //AnzahlWerkstaette++;
                        AktPreis = AktPreis * 2;
                    }
                    break;
                case 4:
                    if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreis)
                    {
                        GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreis);
                        werk5.transform.position = new Vector3(-7.25f, 3.15f, -15.25f);
                        werk5.transform.localScale = new Vector3(6f, 5f, 3.5f);
                        Qualität = Random.Range(0.5f + (AnzahlWerkstaette * 0.05f), 1.5f);
                        buildInProgress = true;
                        //werk5.SetActive(true);
                        //AnzahlWerkstaette++;
                        AktPreis = AktPreis * 2;
                    }
                    break;
                case 5:
                    if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreis)
                    {
                        GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreis);
                        werk6.transform.position = new Vector3(-7.25f, 3.15f, -18.75f);
                        werk6.transform.localScale = new Vector3(6f, 5f, 3.5f);
                        Qualität = Random.Range(0.5f + (AnzahlWerkstaette * 0.05f), 1.5f);
                        buildInProgress = true;
                        //werk6.SetActive(true);
                        //AnzahlWerkstaette++;
                        AktPreis = AktPreis * 2;
                    }
                    break;
                case 6:
                    if (GameObject.Find("Money Display").GetComponent<Money>().money >= AktPreis)
                    {
                        GameObject.Find("Money Display").GetComponent<Money>().Bezahlen(AktPreis);
                        werk7.transform.position = new Vector3(-7.25f, 3.15f, -22.15f);
                        werk7.transform.localScale = new Vector3(6f, 5f, 3.5f);
                        Qualität = Random.Range(0.5f + (AnzahlWerkstaette * 0.05f), 1.5f);
                        buildInProgress = true;
                        //werk7.SetActive(true);
                        //AnzahlWerkstaette++;
                        AktPreis = int.MaxValue;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
