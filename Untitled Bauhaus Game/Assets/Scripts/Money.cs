using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    /*
       (Bug) FUNKTIONIERT ZWAR, "Gehalt" WIRD ABER DIREKT AM ANFANG EIN MAL AUSGEFÜHRT
    */    

    public float money = 20000;
    public Text moneyText;

    private int lastMonth;

    void Start()
    {
        
    }

    void Update()
    {
        moneyText.text = money + " RM";

        //checkMonth();
    }

    public void addGehalt() //Monatliches Gehalt abhängig von der Studentenanzahl und dem Politikmeter
    {
        money += (GameObject.Find("Studenten Counter").GetComponent<Studenten>().StudentenAnzahl * 10) * ((float)GameObject.Find("Politikmeter").GetComponent<Politikmeter>().Politiklevel / 100);
    }

    public void Spende(int spende)
    {
        if (spende > 0)
        {
            money += spende;
        }
    }

    public void Bezahlen(int preis)
    {
		money -= preis;
    }
}
