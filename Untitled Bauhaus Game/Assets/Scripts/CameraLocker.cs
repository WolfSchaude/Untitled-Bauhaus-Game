using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLocker : MonoBehaviour
{
    /// <summary>
    /// Buffer to store the old value, to detect, if a change has even occured
    /// </summary>
    [SerializeField] bool OldState;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    /// <summary>
    /// Locks Cameramovement and tells Quickaccesskeys, that a window got openend
    /// </summary>
    /// <param name = "newState"></param>
    public void ToggleState(bool newState)
    {
        print("Called ToggleState with newState as " + newState);
        if (OldState != newState)
        {
            if (newState)
            {
                Kamera.FreeCameraMovement.Invoke();
                QuickAccesskeys.IClosedAWindow.Invoke();
            }
            else
            {
                Kamera.LockCameraMovement.Invoke();
                QuickAccesskeys.IOpenedAWindow.Invoke();
            }

            OldState = newState;
        }
    }
}
