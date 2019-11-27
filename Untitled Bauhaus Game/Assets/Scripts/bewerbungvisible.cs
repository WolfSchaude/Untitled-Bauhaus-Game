using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class bewerbungvisible : MonoBehaviour
{


    public GameObject bewerbungGameObject;
    public bool showBewerbung;
    public GameObject zuweisenGameObject;
    public bool showZuweisen;


    // Start is called before the first frame update
    void Start()
    {

        bewerbungGameObject.SetActive(false);
        zuweisenGameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("k") && !showZuweisen)
        {
            showBewerbung = !showBewerbung;
            if (showBewerbung)
                bewerbungGameObject.SetActive(true);
            else if (!showBewerbung)
                bewerbungGameObject.SetActive(false);
        }

        if (Input.GetKeyDown("l") && !showBewerbung)
        {
            showZuweisen = !showZuweisen;
            if (showZuweisen)
                zuweisenGameObject.SetActive(true);
            else if (!showZuweisen)
                zuweisenGameObject.SetActive(false);

        }
    }
}
