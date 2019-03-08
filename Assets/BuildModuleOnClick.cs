using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildModuleOnClick : MonoBehaviour, IPointerDownHandler
{
    private OpenModal modalRegistrar;

    private void Start()
    {
        modalRegistrar = FindObjectOfType<OpenModal>();
    }

    public void OnPointerDown(PointerEventData data)
    {
        if (!modalRegistrar.listModules.Open(transform)) return;

        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
