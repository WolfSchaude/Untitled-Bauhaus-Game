using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateBewerber : MonoBehaviour
{

    public GameObject bewerbung;
    public GameObject parent;

    // Start is called before the first frame update
    void Start()
    {

        //for (int i = 0; i < TeacherBuffer.TeacherBufferList.Count; i++)
        {
            GameObject bewerbung1 = Instantiate(bewerbung, GameObject.Find("ContentEinstellen").transform);
            bewerbung1.GetComponentInChildren<Text>().text = "Name: " + TeacherLoader.tb.Buffer[0].Name + Environment.NewLine + "Beruf: " + TeacherLoader.tb.Buffer[0].TeacherBeruf;
            bewerbung1.GetComponent<Image>().sprite = TeacherLoader.tb.Buffer[0].Picture;
            
            GameObject bewerbung2 = Instantiate(bewerbung, GameObject.Find("ContentEinstellen").transform);
            bewerbung2.GetComponentInChildren<Text>().text = "Name: " + TeacherLoader.tb.Buffer[1].Name + Environment.NewLine + "Beruf: " + TeacherLoader.tb.Buffer[1].TeacherBeruf;
            bewerbung2.GetComponent<Image>().sprite = TeacherLoader.tb.Buffer[1].Picture;

            GameObject bewerbung3 = Instantiate(bewerbung, GameObject.Find("ContentEinstellen").transform);
            bewerbung3.GetComponentInChildren<Text>().text = "Name: " + TeacherLoader.tb.Buffer[2].Name + Environment.NewLine + "Beruf: " + TeacherLoader.tb.Buffer[2].TeacherBeruf;
            bewerbung3.GetComponent<Image>().sprite = TeacherLoader.tb.Buffer[2].Picture;
            
            CreateEingestellter();
        }
    }

    void CreateEingestellter()
    {
        GameObject eingestellter1 = Instantiate(bewerbung, parent.transform);
        GameObject eingestellter2 = Instantiate(bewerbung, parent.transform);
        GameObject eingestellter3 = Instantiate(bewerbung, parent.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
