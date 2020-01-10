using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Struktur : MonoBehaviour
{
    public enum Type { Undefiniert, Architektur, Malerei, Ausstellungsgestaltung, Metallwerkstatt, Tischlerei };

    public Type OwnTypeEnum { get; private set; }

    public int OwnTypeInt { get; private set; }

    void Start()
    {
        OwnTypeInt = 0;
        OwnTypeEnum = Type.Undefiniert;
    }


}
