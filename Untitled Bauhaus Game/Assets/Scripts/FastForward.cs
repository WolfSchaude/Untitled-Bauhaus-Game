using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FastForward : MonoBehaviour
{
    public bool fastForwarding = false;
    private bool justToggled = false;

    public static float oldTimeScale = 1;

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
                oldTimeScale = 3f;
            }
            else
            { 
                fastForwardText.text = ">";
                Time.timeScale = 1;
                oldTimeScale = 1f;
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
