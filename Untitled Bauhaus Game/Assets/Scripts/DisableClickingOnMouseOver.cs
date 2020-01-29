using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DisableClickingOnMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        AbilityToClick.DisableClickable.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        AbilityToClick.EnableClickable.Invoke();
    }
}
