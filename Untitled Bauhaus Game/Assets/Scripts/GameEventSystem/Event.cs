using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.Xml.Serialization;

public class Event
{
	[XmlElement("ID")]
	public int ID = 0;

	[XmlElement("Event_Tag")]
	public int Event_Tag = 0;

	[XmlElement("Event_Monat")]
	public int Event_Monat = 0;

	[XmlElement("Event_Jahr")]
	public int Event_Jahr = 0;

	[XmlElement("EventText")]
	public string EventText = "Hello World!";



	[XmlElement("EventOption1")]
	public string EventOption1;

	[XmlElement("Option1_Politik")]
	public int Option1_Politik;

	[XmlElement("Option1_Ansehen")]
	public int Option1_Ansehen;

	[XmlElement("Option1_Geld")]
	public int Option1_Geld;

	[XmlElement("Option1_EffectTicker")]
	public string Option1_EffectTicker;

	[XmlElement("EventOption2")]
	public string EventOption2;

	[XmlElement("Option2_Politik")]
	public int Option2_Politik;

	[XmlElement("Option2_Ansehen")]
	public int Option2_Ansehen;

	[XmlElement("Option2_Geld")]
	public int Option2_Geld;

	[XmlElement("Option2_EffectTicker")]
	public string Option2_EffectTicker;

	[XmlElement("SpecialEvents")]
	public string SpecialEvents;
}
