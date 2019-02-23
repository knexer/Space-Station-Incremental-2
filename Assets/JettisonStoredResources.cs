using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JettisonStoredResources : MonoBehaviour
{
    private Module module;

    // Start is called before the first frame update
    void Start()
    {
        module = GetComponent<Module>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Slot storageSlot in module.OccupiedStorage)
        {
            Destroy(storageSlot.Occupant.gameObject);
        }
    }
}
