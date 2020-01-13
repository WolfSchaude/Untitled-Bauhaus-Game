using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherLoader : MonoBehaviour
{
	public GameObject SaveGameKeeper;
	public TeacherScript Script;


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

	public void Save()
	{
		Debug.Log("Started Saving teachers");
		var x = new bool[HiredTeachers.Count];
		Debug.Log("Generating bool array");
		for (int i = 0; i < HiredTeachers.Count; i++)
		{
			x[i] = HiredTeachers[i].Hired;
		}
		Debug.Log("Saving bool array");
		SaveGameKeeper.GetComponent<SaveGameManager>().Savestate.IsTeacherHired = x;
		Debug.Log("Setting WhoHasSaved 5 to true");
		SaveGameKeeper.GetComponent<SaveGameManager>().WhoHasSaved[5] = true;
	}

	public void Load(Save save)
	{
		for (int i = 0; i < save.IsTeacherHired.Length; i++)
		{
			HiredTeachers[i].Hired = save.IsTeacherHired[i];
		}

		Script.GenerateHiredTeachers();
	}
}