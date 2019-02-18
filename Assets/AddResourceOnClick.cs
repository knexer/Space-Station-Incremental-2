using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Slot))]
public class AddResourceOnClick : MonoBehaviour
{
    [SerializeField] private Resource resourceTemplate;
    private Slot slot;

    private void Start()
    {
        slot = GetComponent<Slot>();
    }

    private void OnMouseDown()
    {
        if (slot.Occupant == null)
        {
            slot.Occupant = Instantiate(resourceTemplate, transform);
        }
    }
}
