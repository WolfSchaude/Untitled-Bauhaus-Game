using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Werkstatt : MonoBehaviour
{
    public enum WerkstattTyp { Undefiniert, Malerei, Architektur, Ausstellungsgestaltung, Metallwerkstatt, Tischlerei };
    public bool IstEinemDozentenZugewiesen;

    // Start is called before the first frame update
    void Start()
    {
        IstEinemDozentenZugewiesen = false;
        WerkstattTyp TypDerWerkstatt = WerkstattTyp.Undefiniert;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
