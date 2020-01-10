using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Struktur : MonoBehaviour
{
    public enum MainType { Undefiniert, Werkstatt, Wohnheim, Lehrsaal };
    public enum Type { Undefiniert, Architektur, Malerei, Ausstellungsgestaltung, Metallwerkstatt, Tischlerei, Wohnheim, Lehrsaal };

    public MainType OwnMainTypeEnum { get; private set; }
    public Type OwnTypeEnum { get; private set; }

    public int OwnMainTypeInt;
    public int OwnTypeInt;

    void Start()
    {
        OwnMainTypeInt = 0;
        OwnMainTypeEnum = MainType.Undefiniert;
        OwnTypeInt = 0;
        OwnTypeEnum = Type.Undefiniert;
    }


}
