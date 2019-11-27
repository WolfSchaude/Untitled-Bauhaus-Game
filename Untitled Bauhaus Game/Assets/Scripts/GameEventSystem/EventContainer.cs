using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("EventCollection")]
public class EventContainer
{
	[XmlArray("Events")]
	[XmlArrayItem("Event")]
	public List<Event> events = new List<Event>();

	public static EventContainer Load(string path)
	{
		TextAsset _xml = Resources.Load<TextAsset>(path);

		XmlSerializer serializer = new XmlSerializer(typeof(TeacherBuffer));

		StringReader reader = new StringReader(_xml.text);

		EventContainer events = serializer.Deserialize(reader) as EventContainer;

		reader.Close();

		return events;
	}

}
