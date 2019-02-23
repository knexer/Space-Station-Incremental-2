using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UnityEngine;

public class Module : MonoBehaviour
{
    [SerializeField] private ResourceSlots StorageSlots;
    [SerializeField] private List<IProcess> processes;

    public IEnumerable<Slot> PushingSlots =>
        processes.Select(process => process.OutputSlot).Where(slot => slot.Occupant != null);

    public IEnumerable<Slot> AvailableStorage => StorageSlots ? StorageSlots.Slots.Where(slot => slot.Occupant == null) : new List<Slot>();

    public ILookup<ResourceType, Slot> PullingSlots =>
        processes.ToLookup(process => process.RequiredResource(), process => process.InputSlot);

    public IEnumerable<Slot> OccupiedStorage =>
        StorageSlots ? StorageSlots.Slots.Where(slot => slot.Occupant != null) : new List<Slot>();

    // Start is called before the first frame update
    void Start()
    {
        processes = new List<IProcess>(GetComponents<IProcess>());
     GetComponentInParent<StationInventoryManager>().Register(this);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
