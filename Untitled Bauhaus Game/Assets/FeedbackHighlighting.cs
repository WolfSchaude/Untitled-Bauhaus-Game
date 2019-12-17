using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedbackHighlighting : MonoBehaviour
{
    int x = 0;
    public GameObject RedBorder;
    public GameObject WhiteFrame;

    void Start()
    {
        GameObject.Find("EventSystem").GetComponent<DatumRelatedEvents>().changedDay.AddListener(() => Increment());
    }

    // Update is called once per frame
    void Update()
    {
        if (x >= 14)
        {
            DisableRedBorder();
        }
    }

    public void DisableRedBorder()
    {
        RedBorder.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
    }

    void Increment()
    {
        x++;
    }
}
