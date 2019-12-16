using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedbackHighlighting : MonoBehaviour
{
    int x = 0;
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
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(380, 60);
    }

    void Increment()
    {
        x++;
    }
}
