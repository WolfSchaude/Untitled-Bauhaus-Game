using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ratgeber : MonoBehaviour
{
    public Animator HelperAnimtor;

    bool Collapsed;
    bool HasClicked = false;
    int SecsSinceLastInput = 20;


    void Start()
    {
        Collapsed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown) HasClicked = true;
        HelperAnimtor.SetBool("Bool", Collapsed);
        if (Time.timeSinceLevelLoad >= SecsSinceLastInput && !HasClicked) Collapsed = false;
    }

    public void ToggleOpened()
    {
        Collapsed = !Collapsed;
    }

    public void CloseOverview()
    {
        Collapsed = true;
    }
}
