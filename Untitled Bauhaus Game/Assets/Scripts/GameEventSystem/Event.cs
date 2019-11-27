using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.Xml.Serialization;

public class Event
{
	[XmlElement("EventText")]
	public Text EventText;



	[XmlElement("EventOption1")]
	public Text EventOption1;

	[XmlElement("Option1_Politik")]
	public int Option1_Politik;

	[XmlElement("Option1_Ansehen")]
	public int Option1_Ansehen;



	[XmlElement("EventOption2")]
	public Text EventOption2;

	[XmlElement("Option2_Politik")]
	public int Option2_Politik;

	[XmlElement("Option2_Ansehen")]
	public int Option2_Ansehen;

}
