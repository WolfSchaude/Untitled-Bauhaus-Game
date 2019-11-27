using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherLoader : MonoBehaviour
{
	private const string path = "XML_Files/LehrerTestList";
	public TeacherBuffer tb;

	void Start()
	{
		tb = TeacherBuffer.Load(path);

		foreach (Teacher teacher in tb.Buffer)
		{
			print(teacher.Name);
			print(teacher.Gehalt);
		}
	}
}