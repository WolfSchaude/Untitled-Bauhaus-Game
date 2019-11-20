using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class realtext1 : MonoBehaviour
{
    public Text bewerbung1text;

    // Start is called before the first frame update
    void Start()
    {
        //this.GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (GameObject.Find("eingestellter1_text").GetComponent<Text>().enabled)
        //{
        //    GameObject.Find("eingestellter1_text").GetComponent<Text>().text = bewerbung1text.text.ToString();
        //}
        //if (GameObject.Find("eingestellter2_text").GetComponent<Text>().enabled)
        //{
        //    GameObject.Find("eingestellter2_text").GetComponent<Text>().text = bewerbung1text.text.ToString();
        //}
        //if (GameObject.Find("eingestellter3_text").GetComponent<Text>().enabled)
        //{
        //    GameObject.Find("eingestellter3_text").GetComponent<Text>().text = bewerbung1text.text.ToString();
        //}
        GameObject.Find("eingestellter1_text").GetComponent<Text>().text = bewerbung1text.text.ToString();
        GameObject.Find("eingestellter2_text").GetComponent<Text>().text = bewerbung1text.text.ToString();
        GameObject.Find("eingestellter3_text").GetComponent<Text>().text = bewerbung1text.text.ToString();
    }
}
