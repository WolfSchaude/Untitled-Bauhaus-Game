using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticMenuBuildingButton_Memory : MonoBehaviour
{
    public int _uniqueID { get; private set; }
    public int _MainType { get; private set; }
    public int _Type { get; private set; }
    public int _MainTypeID { get; private set; }
    public Vector3 _ReferencePosition { get; private set; }
    public Bausystem _BausystemRef { get; private set; }

    public void SetValues(int a, int b, int c, int d, Bausystem system)
    {
        _uniqueID = a;
        _MainType = b;
        _Type = c;
        _MainTypeID = d;
        _BausystemRef = system;
        _ReferencePosition = _BausystemRef.Structures[_uniqueID].transform.position;
    }

    public void OnKlick()
    {
        print("Werte dieses Buttons: " +  _uniqueID + " "+ _MainType + " " + _Type + " " + _MainTypeID);
        print("Position: " + _ReferencePosition);
    }
}
