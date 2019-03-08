using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Slot))]
public class AddResourceOnClick : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Resource resourceTemplate;
    private Slot slot;

    private void Start()
    {
        slot = GetComponent<Slot>();
    }

    public void OnPointerDown(PointerEventData data)
    {
        if (slot.Occupant == null)
        {
            slot.Occupant = Instantiate(resourceTemplate, transform);
        }
    }
}
