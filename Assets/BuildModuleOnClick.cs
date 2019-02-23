﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildModuleOnClick : MonoBehaviour
{
    private OpenModal modalRegistrar;

    private void Start()
    {
        modalRegistrar = FindObjectOfType<OpenModal>();
    }

    private void OnMouseDown()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        modalRegistrar.listModules.Open(transform);
    }
}
