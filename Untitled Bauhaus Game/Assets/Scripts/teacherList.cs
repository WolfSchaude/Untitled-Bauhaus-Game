﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherList : MonoBehaviour
{
	List<Teacher> Teachers;

	public void AddTeacher(Teacher teacher)
	{
		Teachers.Add(teacher);
	}

	public void RemoveTeacher(Teacher teacher)
	{
		Teachers.Remove(Teachers.Find(i => i.Equals(teacher)));
	}

    void Start()
    {
		Teachers = new List<Teacher>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
