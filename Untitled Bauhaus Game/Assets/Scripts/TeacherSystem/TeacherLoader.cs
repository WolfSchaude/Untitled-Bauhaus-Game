using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherLoader : MonoBehaviour
{
	public GameObject SaveGameKeeper;

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
		var x = new List<bool>();
		foreach (var item in HiredTeachers)
		{
			x.Add(item.Hired);
		}

		SaveGameKeeper.GetComponent<SaveGameManager>().Savestate.IsTeacherHired = x;
		SaveGameKeeper.GetComponent<SaveGameManager>().WhoHasSaved[5] = true;
	}

	public void Load(Save save)
	{
		for (int i = 0; i < save.IsTeacherHired.Count; i++)
		{
			HiredTeachers[i].Hired = save.IsTeacherHired[i];
		}
	}
}