using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InWorldEvent_Memory : MonoBehaviour, IClickable
{
    [SerializeField] Event Memory;

    [SerializeField] AnimationStarter AnimStarter;

    private void OnMouseDown()
    {
        OnClick();
    }

    public void OnClick()
    {
        print("InWorldEvent was clicked");

        InWorldEvent._InWorldClickEvent.Invoke(Memory.ID);
        print("_InWorldClickEvent just got invoked with ID: " + Memory.ID);

        AnimStarter.OpenMenu();
    }

    public void SetValues(Event ev, AnimationStarter animationStarter)
    {
        Memory = ev;
        AnimStarter = animationStarter;
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
