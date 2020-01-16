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
    public int OwnStyle;
    public int OwnMainTypeInt;
    public int OwnTypeInt;

    public bool IsPlaced { get; private set; }

    public void Initialise()
    {
        IsPlaced = false;
        OwnMainTypeInt = 0;
        OwnMainTypeEnum = MainType.Undefiniert;
        OwnTypeInt = 0;
        OwnTypeEnum = Type.Undefiniert;
        TypeID = 0;
    }

    public void SetStructure(int Style, int MainType, int Type)
    {
        OwnMainTypeInt = MainType;
        OwnMainTypeEnum = (MainType)MainType;

        OwnTypeInt = Type;
        OwnTypeEnum = (Type)Type;

        OwnStyle = Style;

        IsPlaced = true;
    }

    public void InformCounter()
    {
        switch(OwnTypeEnum)
        {
            case Type.Architektur:
                GameObject.Find("EventSystem").GetComponent<CountGebaeude>().AnzahlArchitektur++;
                break;
            case Type.Ausstellungsgestaltung:
                GameObject.Find("EventSystem").GetComponent<CountGebaeude>().AnzahlAustellung++;
                break;
            case Type.Lehrsaal:
                GameObject.Find("EventSystem").GetComponent<CountGebaeude>().AnzahlLehr++;
                break;
            case Type.Malerei:
                GameObject.Find("EventSystem").GetComponent<CountGebaeude>().AnzahlMalerei++;
                break;
            case Type.Metallwerkstatt:
                GameObject.Find("EventSystem").GetComponent<CountGebaeude>().AnzahlMetall++;
                break;
            case Type.Tischlerei:
                GameObject.Find("EventSystem").GetComponent<CountGebaeude>().AnzahlTisch++;
                break;
            case Type.Wohnheim:
                GameObject.Find("EventSystem").GetComponent<CountGebaeude>().AnzahlWohn++;
                break;
        }
    }
}
