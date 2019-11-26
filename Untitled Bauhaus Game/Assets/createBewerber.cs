using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateBewerber : MonoBehaviour
{
    //RectTransform SomeScrollRect = GameObject.Find("PersonalEinstellen").GetComponent<ScrollRect>();
    public GameObject bewerbung;
    public GameObject parent;

    //public Text name1;
    //public Text name2;
    //public Text name3;
    //Sprite bewSprite1 = Resources.Load("Personen/Person1") as Sprite;

    public RectTransform FindContent(GameObject ScrollViewObject)
    {
        RectTransform RetVal = null;
        Transform[] Temp = ScrollViewObject.GetComponentsInChildren<Transform>();
        foreach (Transform Child in Temp)
        {
            if (Child.name == "Content") { RetVal = Child.gameObject.GetComponent<RectTransform>(); }
        }
        return RetVal;
    }

    // Start is called before the first frame update
    void Start()
    {
        //DefaultControls.Resources TempResource = new DefaultControls.Resources();
        //GameObject NewText = DefaultControls.CreateButton(TempResource);

        //NewText.AddComponent<LayoutElement>();




        GameObject bewerbung1 = Instantiate(bewerbung, GameObject.Find("Content").transform);
        GameObject bewerbung2 = Instantiate(bewerbung, GameObject.Find("Content").transform);
        GameObject bewerbung3 = Instantiate(bewerbung, GameObject.Find("Content").transform);
        //GameObject bewerbung4 = Instantiate(bewerbung, GameObject.Find("Content").transform);
        //GameObject bewerbung5 = Instantiate(bewerbung, GameObject.Find("Content").transform);
        //GameObject bewerbung6 = Instantiate(bewerbung, GameObject.Find("Content").transform);


        //bewerbung1.transform.parent = GameObject.Find("Content").transform;
        //bewerbung1.GetComponentInChildren<Text>().text = TeacherBuffer.TeacherBufferList[0].Name;
        ////bewerbung1.GetComponent<SpriteRenderer>().sprite = Resources.Load("Personen/Person1") as Sprite;
        ////bewerbung1.GetComponentInChildren<Text>().text = TeacherList.Teachers[0].Name;

        ////bewerbung1.transform.position = new Vector3(-140, 100, 0);

        //GameObject bewerbung2 = Instantiate(bewerbung, transform.position, transform.rotation);
        //bewerbung2.transform.parent = GameObject.Find("Content").transform;
        //bewerbung2.transform.SetParent(bewerbung1.transform, false);
        ////bewerbung2.transform.position = new Vector3(-140, 20, 0);

        //GameObject bewerbung3 = Instantiate(bewerbung, transform.position, transform.rotation);
        //bewerbung3.transform.parent = GameObject.Find("Content").transform;
        ////bewerbung3.transform.position = new Vector3(-140, -60, 0);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
