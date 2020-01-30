﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Struktur : MonoBehaviour, IClickable
{
    public GameObject OwnContructionPrefab;
    public enum MainType { Undefiniert, Werkstatt, Wohnheim, Lehrsaal };
    public enum Type { Undefiniert, Architekturwerkstatt, Ausstellungsgestaltung, Malerei, Metallwerkstatt, Tischlerei, Wohnheim, Lehrsaal };

    public MainType OwnMainTypeEnum { get; private set; }
    public Type OwnTypeEnum { get; private set; }

    public int TypeID;
    public int OwnStyle;
    public int OwnMainTypeInt;
    public int OwnTypeInt;

    public bool IsInBuild { get; private set; }
    public bool IsPlaced { get; private set; }

    public void SetContructionPrefab()
    {
        OwnContructionPrefab.transform.position = new Vector3(gameObject.transform.position.x, 1.032f, gameObject.transform.position.z);
        OwnContructionPrefab.SetActive(false);
    }

    public void StartBuilding()
    {
        OwnContructionPrefab.SetActive(true);

        IsInBuild = true;
    }

    public void Initialise()
    {
        IsInBuild = false;
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
        IsInBuild = false;
        OwnContructionPrefab.SetActive(false);
    }

    public void InformCounter()
    {
        switch(OwnTypeEnum)
        {
            case Type.Architekturwerkstatt:
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

    public void OnClick()
    {
        print(gameObject.name + OwnMainTypeEnum + OwnTypeEnum);
    }
}
