using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ratgeber : MonoBehaviour
{
    [SerializeField] AnimationStarter StarterScript;

    bool HasClicked = false;
    int SecsSinceLastInput = 20;


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown) HasClicked = true;

        if (Time.timeSinceLevelLoad >= SecsSinceLastInput && !HasClicked) StarterScript.ToggleOpened();
    }
}
