using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

[System.Serializable]
public class Teacher
{

	[XmlElement("ID", typeof(int))]
	public int ID;

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

	[XmlElement("Geburtsdatum")]
	public string Geburtsdatum;

	[XmlElement("Interessen")]
	public string Interessen;

	[XmlElement("Einstellungskosten")]
	public int Einstellungskosten;

	[XmlElement("FortlaufendeKosten")]
	public int FortlaufendeKosten;

	[XmlElement("SichtbarAb_Tag")]
	public int SichtbarAb_Tag;	
	[XmlElement("SichtbarAb_Monat")]
	public int SichtbarAb_Monat;
	[XmlElement("SichtbarAb_Jahr")]
	public int SichtbarAb_Jahr;

	[XmlIgnore]
	public Sprite Picture;

	[XmlIgnore]
	public GameObject Occupation;
	[XmlIgnore]
	public bool Hired = false;
	[XmlIgnore]
	public bool Zugewiesen = false;

	public void ChangeOccupation(GameObject gameObject)
	{
		Occupation = gameObject;
	}
}
