using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaueWohnheim : MonoBehaviour
{
    int AnzahlWohnheime = 0;

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
                heim1.SetActive(true);
                AnzahlWohnheime++;
                break;
            case 1:
                heim2.SetActive(true);
                AnzahlWohnheime++;
                break;
            case 2:
                heim3.SetActive(true);
                AnzahlWohnheime++;
                break;
            case 3:
                break;
            default:
                break;
        }
    }
}
