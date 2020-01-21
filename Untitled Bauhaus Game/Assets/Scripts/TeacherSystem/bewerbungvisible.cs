using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class bewerbungvisible : MonoBehaviour
{

	public GameObject bewerbungGameObject;
	public GameObject zuweisenGameObject;

	public int zugewiesenenCounter;

    // Start is called before the first frame update
    void Start()
	{
		bewerbungGameObject.SetActive(false);
		zuweisenGameObject.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		if(zugewiesenenCounter < 0)
		{
			zugewiesenenCounter = 0;
		}
    }

	public void ToggleBewerbung()
	{
		if (!zuweisenGameObject.activeSelf)
		{
			if (bewerbungGameObject.activeSelf)
			{
				bewerbungGameObject.SetActive(false);

				Kamera.FreeCameraMovement.Invoke();
			}
			else
			{
				bewerbungGameObject.SetActive(true);
                GameObject.Find("EventSystem").GetComponent<BaumenuDetail>().detailWindow.SetActive(false);

				Kamera.LockCameraMovement.Invoke();
			}
		}
		else
		{
			zuweisenGameObject.SetActive(false);
		}
	}

	public void ToggleZuweisen()
	{
		if (!bewerbungGameObject.activeSelf)
		{
			if (zuweisenGameObject.activeSelf)
			{
				zuweisenGameObject.SetActive(false);

				Kamera.FreeCameraMovement.Invoke();
			}
			else
			{
				zuweisenGameObject.SetActive(true);
                GameObject.Find("EventSystem").GetComponent<BaumenuDetail>().detailWindow.SetActive(false);

				Kamera.LockCameraMovement.Invoke();
			}
		}
		else
		{
			bewerbungGameObject.SetActive(false);
		}
	}
}
