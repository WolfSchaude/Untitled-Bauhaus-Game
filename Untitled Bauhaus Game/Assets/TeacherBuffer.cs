using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherBuffer : MonoBehaviour
{
<<<<<<< HEAD
	public List<Teacher> TeacherBufferList;
=======
	public static List<Teacher> TeacherBufferList;
>>>>>>> bd55bd44f48c8be909b8eda9883d3f5747a0c4b5

    void Start()
    {
		TeacherBufferList.Add(new Teacher("Lyonel Feininger",	Resources.Load("Personen/Person1") as Sprite, Teacher.Status.NotHired, Teacher.Beruf.Kunstmaler, true));
		TeacherBufferList.Add(new Teacher("Josef Albers",		Resources.Load("Personen/Person2") as Sprite, Teacher.Status.NotHired, Teacher.Beruf.Kunstmaler, true));
		TeacherBufferList.Add(new Teacher("Johannes Itten",		Resources.Load("Personen/Person3") as Sprite, Teacher.Status.NotHired, Teacher.Beruf.Kunstmaler, true));
    }


    void Update()
    {
        
    }
}
