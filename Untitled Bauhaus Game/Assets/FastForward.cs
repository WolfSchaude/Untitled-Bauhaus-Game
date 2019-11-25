using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FastForward : MonoBehaviour
{
    public bool fastForwarding = false;
    private bool justToggled = false;

    public Text fastForwardText;

    void Start()
    {
        
    }

    void Update()
    {
        if (justToggled)
        {
            if (fastForwarding)
            {
                fastForwardText.text = ">>>";
                Time.timeScale = 3;
            }
            else
            { 
                fastForwardText.text = ">";
                Time.timeScale = 1;
            }
            justToggled = false;
        }
    }

    public void toggleFastForward() //Fast forward the game
    {
        fastForwarding = !fastForwarding;
        justToggled = true;
    }
}
