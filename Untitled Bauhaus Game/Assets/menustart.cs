using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menustart : MonoBehaviour
{
        public void ChangeScene(string sceneName)
        {
            Application.LoadLevel(sceneName);
        }
    }

