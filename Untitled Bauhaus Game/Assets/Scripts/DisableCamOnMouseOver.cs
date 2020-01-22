using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DisableCamOnMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        Kamera.LockCameraMovement.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Kamera.FreeCameraMovement.Invoke();
    }
}
