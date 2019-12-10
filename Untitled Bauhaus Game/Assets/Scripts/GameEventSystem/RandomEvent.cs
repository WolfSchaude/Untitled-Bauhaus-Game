using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

public class RandomEvent
{
    [XmlIgnore]
    public int Event_Tag;
    [XmlIgnore]
    public int Event_Monat;
    [XmlIgnore]
    public int Event_Jahr;


    [XmlElement("EventText")]
    public string EventText;


    [XmlElement("EventOption1")]
    public string EventOption1;

    [XmlElement("Option1_Politik")]
    public int Option1_Politik;

    [XmlElement("Option1_Ansehen")]
    public int Option1_Ansehen;

    [XmlElement("Option1_Geld")]
    public int Option1_Geld;


    [XmlElement("EventOption2")]
    public string EventOption2;

    [XmlElement("Option2_Politik")]
    public int Option2_Politik;

    [XmlElement("Option2_Ansehen")]
    public int Option2_Ansehen;

    [XmlElement("Option2_Geld")]
    public int Option2_Geld;
}
