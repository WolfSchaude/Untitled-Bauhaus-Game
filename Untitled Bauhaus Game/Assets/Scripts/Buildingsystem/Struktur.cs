using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Struktur : MonoBehaviour
{
    public enum MainType { Undefiniert, Werkstatt, Wohnheim, Lehrsaal };
    public enum Type { Undefiniert, Architektur, Ausstellungsgestaltung, Malerei, Metallwerkstatt, Tischlerei, Wohnheim, Lehrsaal };

    public MainType OwnMainTypeEnum { get; private set; }
    public Type OwnTypeEnum { get; private set; }

    public int TypeID;
    public int OwmStyle;
    public int OwnMainTypeInt;
    public int OwnTypeInt;

    public bool IsPlaced { get; private set; }

    void Start()
    {
        IsPlaced = false;
        OwnMainTypeInt = 0;
        OwnMainTypeEnum = MainType.Undefiniert;
        OwnTypeInt = 0;
        OwnTypeEnum = Type.Undefiniert;
    }

    public void Initialise()
    {
        IsPlaced = false;
        OwnMainTypeInt = 0;
        OwnMainTypeEnum = MainType.Undefiniert;
        OwnTypeInt = 0;
        OwnTypeEnum = Type.Undefiniert;
        TypeID = 0;
    }

    public void SetStructure(int MainType, int Type)
    {
        OwnMainTypeInt = MainType;
        //OwnMainTypeEnum = (MainType)MainType;

        OwnTypeInt = Type;
        //OwnTypeEnum = (Type)Type;
        IsPlaced = true;
    }
}
