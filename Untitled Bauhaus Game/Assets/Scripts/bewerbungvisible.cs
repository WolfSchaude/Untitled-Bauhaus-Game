using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class bewerbungvisible : MonoBehaviour
{

	public GameObject bewerbungGameObject;
	public GameObject zuweisenGameObject;

    // Start is called before the first frame update
    void Start()
	{
		bewerbungGameObject.SetActive(false);
		zuweisenGameObject.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		for (int i = 0; i < TeacherLoader.tb.Buffer.Count - 1; i++)
		{
			
		}
    }

	public void ToggleBewerbung()
	{
		if (!zuweisenGameObject.activeSelf)
		{
			if (bewerbungGameObject.activeSelf)
			{
				bewerbungGameObject.SetActive(false);
			}
			else
			{
				bewerbungGameObject.SetActive(true);
			}
		}
	}

	public void ToggleZuweisen()
	{
		if (!bewerbungGameObject.activeSelf)
		{
			if (zuweisenGameObject.activeSelf)
			{
				zuweisenGameObject.SetActive(false);
			}
			else
			{
				zuweisenGameObject.SetActive(true);
			}
		}
	}
}
