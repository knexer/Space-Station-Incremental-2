using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSlots : MonoBehaviour
{
    [SerializeField] private Vector2[] slotPositions;
    [SerializeField] private Slot slotTemplate;

    public List<Slot> Slots;

    // Start is called before the first frame update
    private void Start()
    {
        Slots = new List<Slot>();
        foreach (Vector2 slotPosition in slotPositions)
        {
            Slot slot = Instantiate(slotTemplate, transform);
            slot.transform.localPosition = slotPosition;
            Slots.Add(slot);
        }
    }
}
