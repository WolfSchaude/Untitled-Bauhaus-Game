using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingTextAnimation : MonoBehaviour
{
    bool isRunning = false;

    int dots = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf && !isRunning)
        {
            StartCoroutine(SmallAnim());
        }
        
    }

    IEnumerator SmallAnim()
    {
        isRunning = true;

        yield return new WaitForSecondsRealtime(0.2f);

        switch (dots)
        {
            case 1:
                gameObject.GetComponent<Text>().text = "Loading..";
                dots++;
                break;
            case 2:
                gameObject.GetComponent<Text>().text = "Loading...";
                dots++;
                break;
            case 3:
                gameObject.GetComponent<Text>().text = "Loading.";
                dots = 1;
                break;
            default:
                gameObject.GetComponent<Text>().text = "Loading.";
                dots = 1;
                break;
        }

        isRunning = false;
    }
}
