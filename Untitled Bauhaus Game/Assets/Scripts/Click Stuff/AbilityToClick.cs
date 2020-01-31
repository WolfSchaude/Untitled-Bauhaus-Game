using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AbilityToClick : MonoBehaviour
{
    /// <summary>
    /// The Tag we use to discern if something is even Highlightable
    /// </summary>
    [SerializeField] string Tag_Highlight = "Clickable";

    /// <summary>
    /// Stores the last Seleted/highlighed object
    /// </summary>
    [SerializeField] private Transform _selection;

    /// <summary>
    /// Stores the status if cursor is elegible to click, gets disabled when over UI-Elements
    /// </summary>
    [SerializeField] private bool AmIAllowedToClick;

    /// <summary>
    /// Static Event to disable the clicking / raycasting
    /// </summary>
    [SerializeField] public static UnityEvent DisableClickable;

    /// <summary>
    /// Static Event to enable the clicking / raycisting
    /// </summary>
    [SerializeField] public static UnityEvent EnableClickable;

    private void Awake()
    {
        if (DisableClickable == null)
        {
            DisableClickable = new UnityEvent();
        }
        if (EnableClickable == null)
        {
            EnableClickable = new UnityEvent();
        }

        DisableClickable.AddListener(() => { DisableClicking(); });
        EnableClickable.AddListener(() => { EnableClicking(); });
    }

    void Update()
    {
        if (AmIAllowedToClick)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, 426.0f))
                {
                    if (hit.transform.CompareTag(Tag_Highlight))
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

    void DisableClicking()
    {
        AmIAllowedToClick = false;
    }

    void EnableClicking()
    {
        AmIAllowedToClick = true;
    }
}
