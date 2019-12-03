using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Werkstatt : MonoBehaviour
{
    public enum WerkstattTyp { Undefiniert, Architektur, Malerei, Ausstellungsgestaltung, Metallwerkstatt, Tischlerei };
    public WerkstattTyp EigenerTyp;
    public bool IstEinemDozentenZugewiesen;

    // Start is called before the first frame update
    void Start()
    {
        IstEinemDozentenZugewiesen = false;
        EigenerTyp = WerkstattTyp.Undefiniert;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetType(int Typ)
    {
        switch(Typ)
        {
            case 0: EigenerTyp = WerkstattTyp.Architektur;
                break;
            case 1: EigenerTyp = WerkstattTyp.Malerei;
                break;
            case 2: EigenerTyp = WerkstattTyp.Ausstellungsgestaltung;
                break;
            case 3: EigenerTyp = WerkstattTyp.Metallwerkstatt;
                break;
            case 4: EigenerTyp = WerkstattTyp.Tischlerei;
                break;
        }
    }
}
