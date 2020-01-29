using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticMenuBuildingButton_Memory : MonoBehaviour
{
    public int _uniqueID { get; private set; }
    public int _MainType { get; private set; }
    public int _Type { get; private set; }
    public int _MainTypeID { get; private set; }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetValues(int a, int b, int c, int d)
    {
        _uniqueID = a;
        _MainType = b;
        _Type = c;
        _MainTypeID = d;
    }

    public void OnKlick()
    {
        print("Werte dieses Buttons: " +  _uniqueID + " "+ _MainType + " " + _Type + " " + _MainTypeID);
    }
}
