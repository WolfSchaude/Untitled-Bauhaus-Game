using UnityEngine;
public class Teacher
{
	readonly public string Name;
	readonly public Sprite Picture;
	public GameObject Occupation;
	public Status TeacherStatus;
	readonly public Beruf TeacherBeruf;

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

	public Teacher()
	{
		Name = "Max Musterman";
		Picture = null;
		TeacherStatus = Status.NotHired;
		TeacherBeruf = Beruf.Architekt;
		Hireable = true;
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
