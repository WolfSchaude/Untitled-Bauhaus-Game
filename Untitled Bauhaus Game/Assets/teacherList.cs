using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherList : MonoBehaviour
{
	public static List<Teacher> Teachers;

	public void AddTeacher(Teacher teacher)
	{
		Teachers.Add(teacher);
	}

	public void RemoveTeacher(Teacher teacher)
	{
		Teachers.Remove(Teachers.Find(i => i.Equals(teacher)));
	}

	public Teacher GetTeacher(int index)
	{
		return Teachers[index];
	}

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
