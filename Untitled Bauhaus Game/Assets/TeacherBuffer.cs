using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherBuffer : MonoBehaviour
{
	public static List<Teacher> TeacherBufferList;

    void Start()
    {
		TeacherBufferList = new List<Teacher>();

		TeacherBufferList.Add(new Teacher("Lyonel Feininger",	Resources.Load("Personen/Person1") as Sprite, Teacher.Status.NotHired, Teacher.Beruf.Kunstmaler, true));
		TeacherBufferList.Add(new Teacher("Josef Albers",		Resources.Load("Personen/Person2") as Sprite, Teacher.Status.NotHired, Teacher.Beruf.Kunstmaler, true));
		TeacherBufferList.Add(new Teacher("Johannes Itten",		Resources.Load("Personen/Person3") as Sprite, Teacher.Status.NotHired, Teacher.Beruf.Kunstmaler, true));
    }


    void Update()
    {
		TeacherBufferList.Add(new Teacher("Lyonel Feininger", Resources.Load("Personen/Person1") as Sprite, Teacher.Status.NotHired, Teacher.Beruf.Kunstmaler, true));
		TeacherBufferList.Add(new Teacher("Josef Albers", Resources.Load("Personen/Person2") as Sprite, Teacher.Status.NotHired, Teacher.Beruf.Kunstmaler, true));
		TeacherBufferList.Add(new Teacher("Johannes Itten", Resources.Load("Personen/Person3") as Sprite, Teacher.Status.NotHired, Teacher.Beruf.Kunstmaler, true));
    }

	public Teacher GetTeacher(int index)
	{
		return TeacherBufferList[index];
	}
}
