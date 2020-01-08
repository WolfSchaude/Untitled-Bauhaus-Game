using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmallAnsehen : MonoBehaviour
{
    public int Ansehen;

    public Text AnsehenText;

    void Start()
    {
        Ansehen = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Ansehen <= 1)
        {
            Ansehen = 1;
        }

        AnsehenText.text = Ansehen.ToString();
    }

    public void ManipulateAnsehen(int wert)
    {
        Ansehen += wert;

        if (Ansehen < 0)
        {
            Ansehen = 0;
        }
    }
}
