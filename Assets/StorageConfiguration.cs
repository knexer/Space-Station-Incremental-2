using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageConfiguration : MonoBehaviour
{
    [SerializeField] private ResourceConfigurator resourceRow;
    [SerializeField] private List<Resource> resources;
    [SerializeField] private StationInventoryManager inventory;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Resource resource in resources)
        {
            Instantiate<ResourceConfigurator>(resourceRow, transform).Init(inventory, resource);
        }
    }
}
