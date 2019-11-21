using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
	private float money = 20000;
	public Text moneyText;

    void Start()
    {
        InvokeRepeating("Gehalt", 0.1f, 5.0f);
    }

    void Update()
    {
        moneyText.text = money + " RM";
		//if (Input.GetKeyDown(KeyCode.Space))
		//{
        //    money -= 1000;
		//}
    }

    public void Gehalt()
    {

        money += (GameObject.Find("Studenten Counter").GetComponent<Studenten>().StudentenAnzahl * 10) * (GameObject.Find("Politikmeter").GetComponent<Politikmeter>().Politiklevel / 100);
    }

	public void Spende(int spende)
	{ 
		if (spende > 0)
		{
			money += spende;
		}
	}
}
