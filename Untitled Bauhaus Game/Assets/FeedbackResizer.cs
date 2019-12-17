using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackResizer : MonoBehaviour
{
    public GameObject Vorlage;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!(gameObject.GetComponent<RectTransform>().sizeDelta == Vector2.zero))
        {
            if (gameObject.name == "Red Outline")
            {
                gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(gameObject.GetComponent<RectTransform>().sizeDelta.x, Vorlage.GetComponent<RectTransform>().sizeDelta.y + 30);
            }
            gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(gameObject.GetComponent<RectTransform>().sizeDelta.x, Vorlage.GetComponent<RectTransform>().sizeDelta.y + 10);
        }
    }
}
