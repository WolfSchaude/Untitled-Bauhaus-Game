using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherLoader : MonoBehaviour
{
	private const string path = "XML_Files/LehrerTestList";
	public static TeacherBuffer tb;

	public List<Teacher> HiredTeachers;

	void Awake()
	{
		tb = TeacherBuffer.Load(path);

		foreach (Teacher teacher in tb.Buffer)
		{
			teacher.Picture = Resources.Load<Sprite>(teacher.ImagePath);
		}

		HiredTeachers = new List<Teacher>();
		HiredTeachers = tb.Buffer;
	}

	public void AddTeacher(Teacher teacher)
	{
		HiredTeachers.Add(teacher);
	}

	public void RemoveTeacher(Teacher teacher)
	{
		HiredTeachers.Remove(HiredTeachers.Find(i => i.Equals(teacher)));
	}

	public Teacher GetTeacher(int index)
	{
		return HiredTeachers[index];
	}

	public Teacher GetBufferTeacher(int index)
	{
		return tb.Buffer[index];
	}
}