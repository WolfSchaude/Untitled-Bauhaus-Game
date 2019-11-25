using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateBewerber : MonoBehaviour
{
    public GameObject bewerbung;
    public GameObject parent;

    Sprite bewSprite1 = Resources.Load("Personen/Person1") as Sprite;

    // Start is called before the first frame update
    void Start()
    {
        GameObject bewerbung1 = Instantiate(bewerbung, transform.position, transform.rotation);
        bewerbung1.transform.parent = GameObject.Find("Content").transform;
        bewerbung1.GetComponent<SpriteRenderer>().sprite = Resources.Load("Personen/Person1") as Sprite;
        
       // TeacherList.Teachers[0].Name

        //bewerbung1.transform.position = new Vector3(-140, 100, 0);
        GameObject bewerbung2 = Instantiate(bewerbung);
        bewerbung2.transform.parent = GameObject.Find("Content").transform;
        bewerbung2.transform.SetParent(bewerbung1.transform, false);
        //bewerbung2.transform.position = new Vector3(-140, 20, 0);
        GameObject bewerbung3 = Instantiate(bewerbung);
        bewerbung3.transform.parent = GameObject.Find("Content").transform;
        //bewerbung3.transform.position = new Vector3(-140, -60, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
