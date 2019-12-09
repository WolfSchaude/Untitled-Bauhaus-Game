using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teacher_Memory : MonoBehaviour
{
    public GameObject Parent;

    public Teacher Memory;

    void Start()
    {
        Memory = new Teacher();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMemory(Teacher teacher, GameObject parent)
    {
        Memory = teacher;
        Parent = parent; 
    }

    public void StelleEin()
    {

    }
}
