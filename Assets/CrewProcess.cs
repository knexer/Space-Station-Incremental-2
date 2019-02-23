using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewProcess : MonoBehaviour, IProcess
{
    [SerializeField] private float produceTime;
    [SerializeField] private Resource outputTemplate;
    [SerializeField] private Slot inputSlot;
    [SerializeField] private Slot outputSlot;

    public Slot InputSlot => inputSlot;
    public Slot OutputSlot => outputSlot;
    
    private float nextProduceTime;

    private void Start()
    {
        nextProduceTime = Time.time;
    }

    private void Update()
    {
        if (inputSlot.Occupant == null)
        {
            nextProduceTime = Time.time + produceTime;
        } else if (Time.time >= nextProduceTime && outputSlot.Occupant == null)
        {
            Destroy(inputSlot.Occupant.gameObject);
            outputSlot.Occupant = Instantiate(outputTemplate, outputSlot.transform);
            nextProduceTime = Time.time + produceTime;
        }
    }

    public ResourceType RequiredResource()
    {
        return ResourceType.LifeSupport;
    }
}

// A process transforms resources from one type into another.
public interface IProcess
{
    ResourceType RequiredResource();
    Slot InputSlot { get; }
    Slot OutputSlot { get; }
}
