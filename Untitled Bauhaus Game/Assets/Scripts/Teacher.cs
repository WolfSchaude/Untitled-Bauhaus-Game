using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
public class Teacher
{

	[XmlElement("Name")]
	public string Name;

	[XmlElement("Beruf")]
	public string TeacherBeruf;

	[XmlElement("Gehalt", typeof(int))]
	public int Gehalt;

	[XmlElement("Politik", typeof(int))]
	public int Politik;

	[XmlElement("ImagePath")]
	public string ImagePath;

	[XmlIgnore]
	public Sprite Picture;

	[XmlIgnore]
	public GameObject Occupation;
	[XmlIgnore]
	public Status TeacherStatus = Status.NotHired;
	[XmlIgnore]
	public bool Hireable = true;


	public enum Status
	{
		Employed, NotEmployed, WorkingOnExponate, NotHired
	}
	public enum Beruf
	{
		Architekt, Kunstmaler, Bildhauer, Schlosser
	}

	//public Teacher(string name, Beruf beruf, int gehalt, int politik, Sprite sprite, bool hireable)
	//{
	//	Name = name;
	//	TeacherBeruf = beruf;
	//	Gehalt = gehalt;
	//	Politik = politik;
	//	Picture = sprite;

	//	TeacherStatus = Status.NotHired;
	//	Occupation = null;

	//	Hireable = hireable;
	//}

	//public Teacher()
	//{
	//	Name = "Max Musterman";
	//	Picture = null;
	//	TeacherStatus = Status.NotHired;
	//	TeacherBeruf = Beruf.Architekt;
	//	Hireable = true;
	//}

	public void ChangeStatus(Status status)
	{
		TeacherStatus = status;
	}

	public void ChangeOccupation(GameObject gameObject)
	{
		Occupation = gameObject;
	}

}
