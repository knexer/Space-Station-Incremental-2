using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildModuleOnClick : MonoBehaviour
{
    [SerializeField] private GameObject module;

    private void OnMouseDown()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        // TODO spawn a module picker GUI or something once there are multiple modules
        Instantiate(module, transform);
    }
}
