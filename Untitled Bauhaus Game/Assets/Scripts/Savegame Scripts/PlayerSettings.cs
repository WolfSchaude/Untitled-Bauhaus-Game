using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerSettings : MonoBehaviour
{
    [SerializeField]
    private int Volume;
    [SerializeField]
    private AudioSource myAudio;

    public void Awake()
    {
        // 1
        if (!PlayerPrefs.HasKey("music"))
        {
            PlayerPrefs.SetInt("music", 50);
            Volume = 50;
            myAudio.enabled = true;
            PlayerPrefs.Save();
        }
        // 2
        else
        {
            Volume = PlayerPrefs.GetInt("music");
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleMusic(int newVolume)
    {
        PlayerPrefs.SetInt("music", newVolume);

        Volume = newVolume;

        PlayerPrefs.Save();
    }
}
