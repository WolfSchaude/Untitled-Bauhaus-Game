using UnityEngine;
public class Teacher
{
	readonly string Name;
	readonly Sprite Picture;
	readonly public Beruf TeacherBeruf;

	GameObject Occupation;
	public Status TeacherStatus;
	bool Hireable;

	public enum Status
	{
		Employed, NotEmployed, WorkingOnExponate, NotHired
	}
	public enum Beruf
	{
		Architekt, Kunstmaler, Bildhauer, Schlosser
	}

	public Teacher(string name, Sprite sprite, Status status, Beruf beruf, bool hireable)
	{
		Name = name;
		Picture = sprite;
		TeacherStatus = status;
		TeacherBeruf = beruf;
		Hireable = hireable;
	}
	
	public void ChangeStatus(Status status)
	{
		TeacherStatus = status;
	}

	public void ChangeOccupation(GameObject gameObject)
	{
		Occupation = gameObject;
	}
}
