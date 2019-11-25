using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    /*
       (Bug) FUNKTIONIERT ZWAR, "Gehalt" WIRD ABER DIREKT AM ANFANG EIN MAL AUSGEFÜHRT
    */    

    private float money = 20000;
    public Text moneyText;

    private int lastMonth;

    void Start()
    {
        lastMonth = GameObject.Find("Datum").GetComponent<TimeKeeper>().currentMonth;
    }

    void Update()
    {
        moneyText.text = money + " RM";

        checkMonth();
    }

    public void Gehalt() //Monatliches Gehalt abhängig von der Studentenanzahl und dem Politikmeter
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
    public void checkMonth() //Check if the month has changed
    {
        if (GameObject.Find("Datum").GetComponent<TimeKeeper>().currentMonth != lastMonth)
        {
            Gehalt();
            lastMonth = GameObject.Find("Datum").GetComponent<TimeKeeper>().currentMonth;
        }
    }
}
