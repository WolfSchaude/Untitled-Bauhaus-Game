using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverOption : MonoBehaviour
{
    public int WhichOptionLoses;
    void Start()
    {
        gameObject.GetComponent<InWorldEvent_Memory>().TimeIsUp.AddListener(() => { GameOver(); });
    }

    void GameOver()
    {
        switch (WhichOptionLoses)
        {
            case 1: GameObject.Find("EventSystem").GetComponent<WinLose>().GameOverThroughEvent(gameObject.GetComponent<Event_Memory>().Memory.Option1_EffectTicker);
                break;
            case 2: GameObject.Find("EventSystem").GetComponent<WinLose>().GameOverThroughEvent(gameObject.GetComponent<Event_Memory>().Memory.Option2_EffectTicker);
                break;
            default:
                break;
        }
    }
}
