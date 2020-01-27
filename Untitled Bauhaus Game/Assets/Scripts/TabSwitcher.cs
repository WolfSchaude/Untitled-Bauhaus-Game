using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabSwitcher : MonoBehaviour
{
    public void MoveToLastSibling(GameObject go)
    {
        go.transform.SetAsLastSibling();
    }
}
