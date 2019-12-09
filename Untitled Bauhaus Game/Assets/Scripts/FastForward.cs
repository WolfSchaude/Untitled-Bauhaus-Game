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

	public static TimeMode Mode = TimeMode.Normal;

	public enum TimeMode
	{
		Normal, FastForward, Stop
	}



    void Start()
    {
        fastForwardText.text = "▸";

		Mode = TimeMode.Normal;
    }

    void Update()
    {
		if (justToggled)
		{
			switch (Mode)
			{
				case TimeMode.Normal:

					fastForwardText.text = "▸";
					Time.timeScale = 1;
					oldTimeScale = 1f;

					break;
				case TimeMode.FastForward:

					fastForwardText.text = "▸▸▸";
					Time.timeScale = 3;
					oldTimeScale = 3f;

					break;
				case TimeMode.Stop:

					fastForwardText.text = "∥";
					Time.timeScale = 0;
					oldTimeScale = 0f;

					break;
				default:
					break;
			}

			justToggled = false;
		}
    }

    public void toggleFastForward() //Fast forward the game
    {
		switch (Mode)
		{
			case TimeMode.Normal:

				Mode = TimeMode.FastForward;

				break;
			case TimeMode.FastForward:

				Mode = TimeMode.Stop;

				break;
			case TimeMode.Stop:

				Mode = TimeMode.Normal;

				break;
			default:
				break;
		}

		justToggled = true;
	}
}
