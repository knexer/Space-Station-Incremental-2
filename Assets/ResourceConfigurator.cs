using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ResourceConfigurator : MonoBehaviour
{
    [SerializeField] private Text Name;
    [SerializeField] private Image Icon;
    [SerializeField] private Slider Minimum;
    [SerializeField] private Text MinDescription;
    [SerializeField] private Slider Maximum;
    [SerializeField] private Text MaxDescription;

    private StationInventoryManager inventory;
    private ResourceType resource;

    public void Init(StationInventoryManager inventory, Resource resource)
    {
        this.inventory = inventory;
        this.resource = resource.Type;

        Name.text = resource.Type.ToString();
        Icon.sprite = resource.GetComponent<SpriteRenderer>().sprite;
        Minimum.maxValue = inventory.Storage.Count();
        Minimum.wholeNumbers = true;
        Minimum.onValueChanged.AddListener(OnMinimumChanged);
        Maximum.maxValue = inventory.Storage.Count();
        Maximum.wholeNumbers = true;
        Maximum.onValueChanged.AddListener(OnMaximumChanged);
    }

    private void OnMinimumChanged(float value)
    {
        MinDescription.text = $"Min:{(int) value}";
        inventory.SetMinimum(resource, (int) value);
    }

    private void OnMaximumChanged(float value)
    {
        MaxDescription.text = $"Max:{(int) value}";
        inventory.SetMaximum(resource, (int)value);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
