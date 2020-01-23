﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class bewerbungvisible : MonoBehaviour
{ 
	public GameObject bewerbungGameObject;
	public GameObject zuweisenGameObject;

    void Start()
	{
		bewerbungGameObject.SetActive(false);
		zuweisenGameObject.SetActive(false);
	}
	void Update()
	{

    }

	public void ToggleBewerbung()
	{
		if (zuweisenGameObject.activeSelf)
		{
			zuweisenGameObject.SetActive(false);
			Kamera.FreeCameraMovement.Invoke();
			QuickAccesskeys.IClosedAWindow.Invoke();
		}
		else
		{
			if (bewerbungGameObject.activeSelf)
			{
				bewerbungGameObject.SetActive(false);
				Kamera.FreeCameraMovement.Invoke();
				QuickAccesskeys.IClosedAWindow.Invoke();
			}
			else
			{
				bewerbungGameObject.SetActive(true);
				Kamera.LockCameraMovement.Invoke();
				QuickAccesskeys.IOpenedAWindow.Invoke();
			}
		}
	}

	public void ToggleZuweisen()
	{
		if (bewerbungGameObject.activeSelf)
		{
			bewerbungGameObject.SetActive(false);
			Kamera.FreeCameraMovement.Invoke();
			QuickAccesskeys.IClosedAWindow.Invoke();
		}
		else
		{
			if (zuweisenGameObject.activeSelf)
			{
				zuweisenGameObject.SetActive(false);
				Kamera.FreeCameraMovement.Invoke();
				QuickAccesskeys.IClosedAWindow.Invoke();
			}
			else
			{
				zuweisenGameObject.SetActive(true);
				Kamera.LockCameraMovement.Invoke();
				QuickAccesskeys.IOpenedAWindow.Invoke();
			}
		}
	}

	public void CloseWindows()
	{
		bewerbungGameObject.SetActive(false);
		zuweisenGameObject.SetActive(false);
	}
}
