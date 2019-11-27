using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateBewerber : MonoBehaviour
{

    public GameObject bewerbung;
    public GameObject parent;

    public static bool eingestellter1active = false;
    public static bool eingestellter2active = false;
    public static bool eingestellter3active = false;

    // Start is called before the first frame update
    void Start()
    {

        //for (int i = 0; i < TeacherBuffer.TeacherBufferList.Count; i++)
        {
            GameObject bewerbung1 = Instantiate(bewerbung, GameObject.Find("ContentEinstellen").transform);
            GameObject eingestellter1 = Instantiate(bewerbung, parent.transform);
            eingestellter1.SetActive(false);
            bewerbung1.GetComponentInChildren<Text>().text = "Name: " + TeacherLoader.tb.Buffer[0].Name + Environment.NewLine + "Beruf: " + TeacherLoader.tb.Buffer[0].TeacherBeruf;
            bewerbung1.GetComponent<Image>().sprite = TeacherLoader.tb.Buffer[0].Picture;
            bewerbung1.GetComponent<Button>().onClick.AddListener(() => { eingestellter1.SetActive(true); eingestellter1.GetComponent<Image>().sprite = TeacherLoader.tb.Buffer[0].Picture; eingestellter1.GetComponentInChildren<Text>().text = "Name: " + TeacherLoader.tb.Buffer[0].Name + Environment.NewLine + "Beruf: " + TeacherLoader.tb.Buffer[0].TeacherBeruf; bewerbung1.SetActive(false); eingestellter1active = true; });

            GameObject bewerbung2 = Instantiate(bewerbung, GameObject.Find("ContentEinstellen").transform);
            GameObject eingestellter2 = Instantiate(bewerbung, parent.transform);
            eingestellter2.SetActive(false);
            bewerbung2.GetComponentInChildren<Text>().text = "Name: " + TeacherLoader.tb.Buffer[1].Name + Environment.NewLine + "Beruf: " + TeacherLoader.tb.Buffer[1].TeacherBeruf;
            bewerbung2.GetComponent<Image>().sprite = TeacherLoader.tb.Buffer[1].Picture;
            bewerbung2.GetComponent<Button>().onClick.AddListener(() => { eingestellter2.SetActive(true); eingestellter2.GetComponent<Image>().sprite = TeacherLoader.tb.Buffer[1].Picture; eingestellter2.GetComponentInChildren<Text>().text = "Name: " + TeacherLoader.tb.Buffer[1].Name + Environment.NewLine + "Beruf: " + TeacherLoader.tb.Buffer[1].TeacherBeruf; bewerbung2.SetActive(false); eingestellter2active = true; });

            GameObject bewerbung3 = Instantiate(bewerbung, GameObject.Find("ContentEinstellen").transform);
            GameObject eingestellter3 = Instantiate(bewerbung, parent.transform);
            eingestellter3.SetActive(false);
            bewerbung3.GetComponentInChildren<Text>().text = "Name: " + TeacherLoader.tb.Buffer[2].Name + Environment.NewLine + "Beruf: " + TeacherLoader.tb.Buffer[2].TeacherBeruf;
            bewerbung3.GetComponent<Image>().sprite = TeacherLoader.tb.Buffer[2].Picture;
            bewerbung3.GetComponent<Button>().onClick.AddListener(() => { eingestellter3.SetActive(true); eingestellter3.GetComponent<Image>().sprite = TeacherLoader.tb.Buffer[2].Picture; eingestellter3.GetComponentInChildren<Text>().text = "Name: " + TeacherLoader.tb.Buffer[2].Name + Environment.NewLine + "Beruf: " + TeacherLoader.tb.Buffer[2].TeacherBeruf; bewerbung3.SetActive(false); eingestellter3active = true; });

        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
