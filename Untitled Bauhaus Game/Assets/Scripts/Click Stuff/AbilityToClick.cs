using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityToClick : MonoBehaviour
{
    /// <summary>
    /// The Tag we use to discern if something is even Highlightable
    /// </summary>
    [SerializeField] string Tag = "Clickable";

    ///// <summary>
    ///// Stores the Highlighted Shader
    ///// </summary>
    //[SerializeField] Shader Outline;
    ///// <summary>
    ///// Stores the normal Unity Standard Shader
    ///// </summary>
    //[SerializeField] Shader Standard;

    /// <summary>
    /// Stores the last Seleted/highlighed object
    /// </summary>
    [SerializeField] private Transform _selection;

    void Start()
    {
        //Standard = Shader.Find("Standard");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000.0f))
            {
                if (hit.transform.CompareTag(Tag))
                {
                    if (hit.transform != _selection)
                    {
                        if (_selection != null)
                        {
                            _selection.transform.localScale = Vector3.one;
                        }

                        _selection = hit.transform;

                        hit.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);

                        Struktur struktur;
                        if (struktur = hit.transform.GetComponent<Struktur>())
                        {
                            struktur.OnClick();
                        }
                    }
                    else
                    {
                        print("Das Hast du doch schon angeclickt;");
                    }
                }
                else
                {
                    if (_selection != null)
                    {
                        _selection.transform.localScale = Vector3.one;
                        _selection = null;
                    }
                }
            }
        }
    }
}
