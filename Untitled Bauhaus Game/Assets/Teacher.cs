using UnityEngine;
public class Teacher : MonoBehaviour
{
	readonly public string Name;
	readonly public Sprite Picture;
	readonly public GameObject Employed;
	readonly public Status TeacherStatus;
	readonly public Beruf TeacherBeruf;

	public enum Status
	{
		Employed, NotEmployed, WorkingOnExponate, NotHired
	}
	public enum Beruf
	{
		Architekt, Kunstmaler, Bildhauer, Schlosser
	}

	public Teacher(string name, Sprite sprite, Status status, Beruf beruf)
	{
		Name = name;
		Picture = sprite;
		TeacherStatus = status;
		TeacherBeruf = beruf;
	}

	//public Teacher(string name, Sprite sprite, Status status, Beruf beruf)
	//{
	//	Name = name;
	//	Picture = sprite;
	//	TeacherStatus = status;
	//	TeacherBeruf = beruf;
	//}
}
