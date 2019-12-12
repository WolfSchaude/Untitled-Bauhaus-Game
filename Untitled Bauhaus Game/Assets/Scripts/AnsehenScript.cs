using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnsehenScript : MonoBehaviour
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
		//if (Input.GetKeyDown(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
		//{
		//    Ansehen--;

		if (Ansehen <= 1)
		{
			Ansehen = 1;
		}
		//}

		//if (Input.GetKeyDown(KeyCode.A) && Input.GetKey(KeyCode.LeftControl))
		//{
		//    Ansehen++;
		//}

		AnsehenText.text = "Ansehen: " + Ansehen;
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
