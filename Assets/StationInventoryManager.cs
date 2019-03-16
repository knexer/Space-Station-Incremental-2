using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StationInventoryManager : MonoBehaviour
{
    private List<Module> modules = new List<Module>();

    public void Register(Module module) => modules.Add(module);

    public IEnumerable<Slot> Storage => modules.SelectMany(
        module => module.AvailableStorage.Concat(module.OccupiedStorage));

    private Dictionary<ResourceType, int> minimums = new Dictionary<ResourceType, int>();
    private Dictionary<ResourceType, int> maximums = new Dictionary<ResourceType, int>();

    public void SetMinimum(ResourceType resource, int minimum)
    {
        minimums[resource] = minimum;
    }

    public void SetMaximum(ResourceType resource, int maximum)
    {
        maximums[resource] = maximum;
    }

    // Update is called once per frame
    void Update()
    {
        // TODO don't do this every frame
        // 1. Push outputs to storage.
        IEnumerable<Slot> pushingSlots = modules.SelectMany(module => module.PushingSlots).Where(slot => slot.Occupant != null);
        List<Slot> availableStorage = modules.SelectMany(module => module.AvailableStorage).ToList();
        int usedStorage = 0;
        
        Debug.Log(pushingSlots.Count() + " resources being pushed.");
        Debug.Log(availableStorage.Count() + " available storage spots.");

        foreach (Slot pushingSlot in pushingSlots)
        {
            if (usedStorage >= availableStorage.Count)
            {
                break;
            }
            MoveResource(pushingSlot, availableStorage[usedStorage]);
            usedStorage++;
        }

        // 2. Pull inputs from storage
        ILookup<ResourceType, Slot> pullingSlots = modules
            .Select(module => module.PullingSlots)
            .SelectMany(lookup => lookup)
            .SelectMany(group => group.Select(value => new {group.Key, value}))
            .ToLookup(element => element.Key, element => element.value);
        IEnumerable<Slot> occupiedStorage = modules.SelectMany(module => module.OccupiedStorage);
        foreach (Slot sourceSlot in occupiedStorage)
        {
            if (!pullingSlots.Contains(sourceSlot.Occupant.Type)) continue;
            Slot destinationSlot = pullingSlots[sourceSlot.Occupant.Type]
                .FirstOrDefault(candidate => candidate.Occupant == null);
            if (destinationSlot != null)
            {
                MoveResource(sourceSlot, destinationSlot);
            }
        }
        // TODO 3. Pull inputs from outputs (this one may be optional as it's implicit in 2 & 3 if there's empty storage space on board)
    }

    private void MoveResource(Slot from, Slot to)
    {
        to.Occupant = from.Occupant;
        from.Occupant = null;
        to.Occupant.transform.SetParent(to.transform, false);
    }
}
