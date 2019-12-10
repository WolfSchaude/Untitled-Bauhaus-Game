using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Werkstatt : MonoBehaviour
{
    public enum WerkstattTyp { Undefiniert, Architektur, Malerei, Ausstellungsgestaltung, Metallwerkstatt, Tischlerei };
    public WerkstattTyp EigenerTyp;

    public bool IstEinemDozentenZugewiesen;

    public int DebugWST;

    void Start()
    {
        IstEinemDozentenZugewiesen = false;
        //Debug.Log("hi");
    }

    public void SetType(int Typ)
    {
        DebugWST = Typ;
        switch (Typ)
        {
            case 1:
                EigenerTyp = WerkstattTyp.Architektur;
                break;
            case 2:
                EigenerTyp = WerkstattTyp.Malerei;
                break;
            case 3:
                EigenerTyp = WerkstattTyp.Ausstellungsgestaltung;
                break;
            case 4:
                EigenerTyp = WerkstattTyp.Metallwerkstatt;
                break;
            case 5:
                EigenerTyp = WerkstattTyp.Tischlerei;
                break;
        }
    }
}
