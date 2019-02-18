using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSlots : MonoBehaviour
{
    [SerializeField] private Vector2[] slotPositions;
    [SerializeField] private Slot slotTemplate;

    private List<Slot> slots;

    // Start is called before the first frame update
    private void Start()
    {
        slots = new List<Slot>();
        foreach (Vector2 slotPosition in slotPositions)
        {
            Slot slot = Instantiate(slotTemplate, transform);
            slot.transform.localPosition = slotPosition;
            slots.Add(slot);
        }
    }
}
