using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaueLehrsaal : MonoBehaviour
{
    int AnzahlLehrsaal = 0;

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
        
    }
    public void NeuerLehrsaal()
    {
        switch (AnzahlLehrsaal)
        {
            case 0:
                lehr1.SetActive(true);
                AnzahlLehrsaal++;
                break;
            case 1:
                lehr2.SetActive(true);
                AnzahlLehrsaal++;
                break;
            case 2:
                lehr3.SetActive(true);
                AnzahlLehrsaal++;
                break;
            case 3:
                break;
            default:
                break;
        }
    }
}
