using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickAccesskeys : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)) ; //Baumenue oeffnen
        if (Input.GetKeyDown(KeyCode.E)) ; //Exponat herstellen
        if (Input.GetKeyDown(KeyCode.H)) ; //Buerogebaeude anzeigen / Statistiken
        if (Input.GetKeyDown(KeyCode.I)) ; //Inventar oeffnen
        if (Input.GetKeyDown(KeyCode.T)) ; //Ticker oeffnen / schliessen
        if (Input.GetKeyDown(KeyCode.U)) ; //Eventmenue oeffnen
        if (Input.GetKeyDown(KeyCode.Alpha1)) ; //Tempo auf Nomral
        if (Input.GetKeyDown(KeyCode.Alpha2)) ; //Tempo auf Fast
        if (Input.GetKeyDown(KeyCode.Space)) ; //Pausieren oder Tempo durchschalten
        if (Input.GetKeyDown(KeyCode.Escape)) ; //Fenster schließen
    }
}
