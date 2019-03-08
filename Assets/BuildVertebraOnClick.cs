using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildVertebraOnClick : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private VertebraMaker vertebraMaker;

    public void OnPointerDown(PointerEventData data)
    {
        vertebraMaker.AddVertebra();
    }
}
