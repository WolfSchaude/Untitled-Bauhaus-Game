using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherLoader : MonoBehaviour
{
	public GameObject SaveGameKeeper;
	public TeacherScript Script;


	private const string path = "XML_Files/FormmeisterList";
	public static TeacherBuffer tb;

	void Awake()
	{
		tb = TeacherBuffer.Load(path);

		foreach (Teacher teacher in tb.Buffer)
		{
			teacher.Picture = Resources.Load<Sprite>(teacher.ImagePath);
		}
	}
}