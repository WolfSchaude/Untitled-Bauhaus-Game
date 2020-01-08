using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EasterEgg : MonoBehaviour
{
    public GameObject UI;

    private bool EasterEggBool = false;

    private Quaternion buffer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R) && Input.GetKey(KeyCode.O) && Input.GetKey(KeyCode.F) && Input.GetKey(KeyCode.L) && !EasterEggBool)
        {
            foreach ( Transform transform in UI.transform)
            {
                transform.gameObject.AddComponent<Beyblade>();
            }

            EasterEggBool = true;

            buffer = UI.transform.rotation;

            StartCoroutine("RemoveAfter10Secs");
        }
    }

    IEnumerator RemoveAfter10Secs()
    {
        yield return new WaitForSecondsRealtime(10);

        foreach (Transform transform in UI.transform)
        {
            Destroy(transform.gameObject.GetComponent<Beyblade>());

            transform.rotation = buffer;
        }

        EasterEggBool = false;
    }
}
