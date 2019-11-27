using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zuweisen : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.Find("eingestellter1").activeSelf == true)
        {
            GameObject.Find("eingestellter1").GetComponent<Button>().onClick.AddListener(() => { GameObject.Find("eingestellter1").GetComponent<Renderer>().material.color = Color.black; });
        }
    }
}