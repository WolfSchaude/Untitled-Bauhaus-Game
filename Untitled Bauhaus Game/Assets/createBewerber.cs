using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateBewerber : MonoBehaviour
{

    public GameObject bewerbung;
    public GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        //for (int i = 0; i < TeacherBuffer.TeacherBufferList.Count; i++)
        {
            //GameObject bewerbung1 = Instantiate(bewerbung, GameObject.Find("Content").transform);         //Habs btw estmal bewerbung1 auskommentiert damit du sihest wie eigentlich funktioniert
            //bewerbung1.GetComponentInChildren<Text>().text = TeacherBuffer.TeacherBufferList[0].Name;     //Sollte eigentlich auch gehen allerdings wird dann kein Objekt mehr erstellt da es die TeacherBufferList nicht lesen kann?
            GameObject bewerbung2 = Instantiate(bewerbung, GameObject.Find("Content").transform);           //mit "k" kannst du dann ngame das meu öffnen und siehst dass der text geändert wird nur jklappt das nicht so mit deiner liste
            bewerbung2.GetComponentInChildren<Text>().text = "So sollte es eigentlich funktionieren";
            GameObject bewerbung3 = Instantiate(bewerbung, GameObject.Find("Content").transform);
        }

        //GameObject bewerbung4 = Instantiate(bewerbung, GameObject.Find("Content").transform);
        //GameObject bewerbung5 = Instantiate(bewerbung, GameObject.Find("Content").transform);
        //GameObject bewerbung6 = Instantiate(bewerbung, GameObject.Find("Content").transform);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
