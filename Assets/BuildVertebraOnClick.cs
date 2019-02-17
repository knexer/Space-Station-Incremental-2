using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildVertebraOnClick : MonoBehaviour
{
    [SerializeField] private VertebraMaker vertebraMaker;

    private void OnMouseDown()
    {
        vertebraMaker.AddVertebra();
    }
}
