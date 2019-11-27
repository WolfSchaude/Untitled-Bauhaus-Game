using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaueWerkstatt : MonoBehaviour
{
    int AnzahlWerkstaette = 0;

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
        
    }


    public void NeueWerkstatt()
    {
        switch (AnzahlWerkstaette)
        {
            case 0:
                werk1.SetActive(true);
                AnzahlWerkstaette++;
                break;
            case 1:
                //GameObject.Find("Werkstatt_2").SetActive(true);
                werk2.SetActive(true);
                AnzahlWerkstaette++;
                break;
            case 2:
                //GameObject.Find("Werkstatt_3").SetActive(true);
                werk3.SetActive(true);
                AnzahlWerkstaette++;
                break;
            case 3:
                break;
            default:
                break;
        }
    }
}
