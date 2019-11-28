using UnityEngine;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("TeacherCollection")]
public class TeacherBuffer
{
	[XmlArray("Teachers")]
	[XmlArrayItem("Teacher")]
	public List<Teacher> Buffer;

	public static TeacherBuffer Load(string path)
	{
		TextAsset _xml = Resources.Load<TextAsset>(path);

		XmlSerializer serializer = new XmlSerializer(typeof(TeacherBuffer));

		StringReader reader = new StringReader(_xml.text);

		TeacherBuffer teachers = serializer.Deserialize(reader) as TeacherBuffer;

		reader.Close();

		return teachers;
	}
	public Teacher GetTeacher(int index)
	{
		return Buffer[index];
	}
}
