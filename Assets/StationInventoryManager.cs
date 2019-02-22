using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StationInventoryManager : MonoBehaviour
{
    private List<Module> modules = new List<Module>();

    public void Register(Module module) => modules.Add(module);

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
        }

        // TODO 2. Pull inputs from storage
        // TODO 3. Pull inputs from outputs (this one may be optional as it's implicit in 2 & 3 if there's empty storage space on board)
    }

    private void MoveResource(Slot from, Slot to)
    {
        to.Occupant = from.Occupant;
        from.Occupant = null;
        to.Occupant.transform.SetParent(to.transform, false);
    }
}
