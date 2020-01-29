using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eventlaeuftab : MonoBehaviour
{
    [SerializeField] float Max = 90;
    [SerializeField] float StartWert = 1;
    [SerializeField] float AktuelleProzent;

    Image _Image;

    void Start()
    {
        _Image = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        AktuelleProzent = StartWert / Max;
        _Image.fillAmount = AktuelleProzent;
    }

    public void CountUp()
    {
        StartWert++;
    }
}
