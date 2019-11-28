using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateBewerber : MonoBehaviour
{

    public GameObject bewerbung;
    public GameObject parent;

    public List<GameObject> bewerbungen = new List<GameObject>();
	public List<GameObject> eingestellter = new List<GameObject>();

    public static bool eingestellter1active = false;
    public static bool eingestellter2active = false;
    public static bool eingestellter3active = false;

	// Start is called before the first frame update
	void Start()
	{
		for (int i = 0; i < TeacherLoader.tb.Buffer.Count - 1; i++)
		{ 
            if (TeacherLoader.tb.Buffer[i].Hireable)
            {
                bewerbungen.Add(Instantiate(bewerbung, GameObject.Find("ContentEinstellen").transform));
                bewerbungen[i].GetComponentInChildren<Text>().text = "Name: " + TeacherLoader.tb.Buffer[i].Name + Environment.NewLine + "Beruf: " + TeacherLoader.tb.Buffer[i].TeacherBeruf;
                bewerbungen[i].GetComponent<Image>().sprite = TeacherLoader.tb.Buffer[i].Picture;
                bewerbungen[i].GetComponent<Button>().onClick.AddListener(() => { TeacherLoader.HiredTeachers.Add(TeacherLoader.tb.GetTeacher(i)); });
				bewerbungen[i].GetComponent<Button>().onClick.AddListener(() => { bewerbungen[i].SetActive(false); });
            }
        }




        //for (int i = 0; i < TeacherBuffer.TeacherBufferList.Count; i++)
        {
            //GameObject bewerbung1 = Instantiate(bewerbung, GameObject.Find("ContentEinstellen").transform);
            //GameObject eingestellter1 = Instantiate(bewerbung, parent.transform);
            //eingestellter1.SetActive(false);
            //bewerbung1.GetComponentInChildren<Text>().text = "Name: " + TeacherLoader.tb.Buffer[0].Name + Environment.NewLine + "Beruf: " + TeacherLoader.tb.Buffer[0].TeacherBeruf;
            //bewerbung1.GetComponent<Image>().sprite = TeacherLoader.tb.Buffer[0].Picture;
            //bewerbung1.GetComponent<Button>().onClick.AddListener(() => { eingestellter1.SetActive(true); eingestellter1.GetComponent<Image>().sprite = TeacherLoader.tb.Buffer[0].Picture; eingestellter1.GetComponentInChildren<Text>().text = "Name: " + TeacherLoader.tb.Buffer[0].Name + Environment.NewLine + "Beruf: " + TeacherLoader.tb.Buffer[0].TeacherBeruf; bewerbung1.SetActive(false); eingestellter1active = true; });

            //GameObject bewerbung2 = Instantiate(bewerbung, GameObject.Find("ContentEinstellen").transform);
            //GameObject eingestellter2 = Instantiate(bewerbung, parent.transform);
            //eingestellter2.SetActive(false);
            //bewerbung2.GetComponentInChildren<Text>().text = "Name: " + TeacherLoader.tb.Buffer[1].Name + Environment.NewLine + "Beruf: " + TeacherLoader.tb.Buffer[1].TeacherBeruf;
            //bewerbung2.GetComponent<Image>().sprite = TeacherLoader.tb.Buffer[1].Picture;
            //bewerbung2.GetComponent<Button>().onClick.AddListener(() => { eingestellter2.SetActive(true); eingestellter2.GetComponent<Image>().sprite = TeacherLoader.tb.Buffer[1].Picture; eingestellter2.GetComponentInChildren<Text>().text = "Name: " + TeacherLoader.tb.Buffer[1].Name + Environment.NewLine + "Beruf: " + TeacherLoader.tb.Buffer[1].TeacherBeruf; bewerbung2.SetActive(false); eingestellter2active = true; });

            //GameObject bewerbung3 = Instantiate(bewerbung, GameObject.Find("ContentEinstellen").transform);
            //GameObject eingestellter3 = Instantiate(bewerbung, parent.transform);
            //eingestellter3.SetActive(false);
            //bewerbung3.GetComponentInChildren<Text>().text = "Name: " + TeacherLoader.tb.Buffer[2].Name + Environment.NewLine + "Beruf: " + TeacherLoader.tb.Buffer[2].TeacherBeruf;
            //bewerbung3.GetComponent<Image>().sprite = TeacherLoader.tb.Buffer[2].Picture;
            //bewerbung3.GetComponent<Button>().onClick.AddListener(() => { eingestellter3.SetActive(true); eingestellter3.GetComponent<Image>().sprite = TeacherLoader.tb.Buffer[2].Picture; eingestellter3.GetComponentInChildren<Text>().text = "Name: " + TeacherLoader.tb.Buffer[2].Name + Environment.NewLine + "Beruf: " + TeacherLoader.tb.Buffer[2].TeacherBeruf; bewerbung3.SetActive(false); eingestellter3active = true; });

        }
    }

    // Update is called once per frame
    void Update()
    {
		for (int i = 0; i < TeacherLoader.HiredTeachers.Count; i++)
		{
			if (!TeacherLoader.HiredTeachers[i].IsAdded)
			{
				eingestellter.Add(Instantiate(bewerbung, parent.transform));
				eingestellter[i].GetComponentInChildren<Text>().text = "Name: " + TeacherLoader.tb.Buffer[i].Name + Environment.NewLine + "Beruf: " + TeacherLoader.tb.Buffer[i].TeacherBeruf;
				eingestellter[i].GetComponent<Image>().sprite = TeacherLoader.tb.Buffer[i].Picture;
				eingestellter[i].GetComponent<Button>().onClick.AddListener(() => { Debug.Log("Du willst einen Angestellten zuweisen?" + i); });
				TeacherLoader.HiredTeachers[i].IsAdded = true;
			}
		}
	}
}
