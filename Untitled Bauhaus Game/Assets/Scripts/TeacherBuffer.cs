using UnityEngine;
using System.Collections;
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

    void Start()
    {
		//Buffer = new List<Teacher>
		//{
		//	new Teacher("Lyonel Feininger", Teacher.Beruf.Kunstmaler, 2000, 100, Resources.Load("Personen/Person1") as Sprite, true),
		//	new Teacher("Josef Albers",		Teacher.Beruf.Kunstmaler, 2000, 100, Resources.Load("Personen/Person2") as Sprite, true),
		//	new Teacher("Johannes Itten",	Teacher.Beruf.Kunstmaler, 2000, 100, Resources.Load("Personen/Person3") as Sprite, true)
		//};
	}

	public Teacher GetTeacher(int index)
	{
		return Buffer[index];
	}
}
