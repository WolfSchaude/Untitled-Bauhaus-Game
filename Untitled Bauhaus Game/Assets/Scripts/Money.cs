using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Money : MonoBehaviour
{
	private int money = 20000;
	public Text moneyText;

		
    void Update()
    {
		moneyText.text = money + " RM";
		if (Input.GetKeyDown(KeyCode.Space))
		{
			money -= 1000;
		}
    }

	public void Spende(int spende)
	{
		if (spende > 0)
		{
			money += spende;
		}
	}
}
