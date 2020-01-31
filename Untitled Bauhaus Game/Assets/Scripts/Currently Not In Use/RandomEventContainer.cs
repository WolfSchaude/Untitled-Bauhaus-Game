using UnityEngine;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("EventCollection")]
public class RandomEventContainer
{
	[XmlArray("Events")]
	[XmlArrayItem("RandomEvent")]
	public List<RandomEvent> RandomEvents;

	public static RandomEventContainer Load(string path)
	{
		TextAsset _xml = Resources.Load<TextAsset>(path);

		XmlSerializer serializer = new XmlSerializer(typeof(RandomEventContainer));

		StringReader reader = new StringReader(_xml.text);

		RandomEventContainer randoms = serializer.Deserialize(reader) as RandomEventContainer;

		reader.Close();

		return randoms;
	}
}
