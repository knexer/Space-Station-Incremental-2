using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListModules : MonoBehaviour
{
    [SerializeField] private List<Module> moduleTypes;
    [SerializeField] private GameObject moduleViewTemplate;
    [SerializeField] private RectTransform moduleViewContainer;
    [SerializeField] private GameObject clickBlocker;

    private Transform destination;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Module moduleType in moduleTypes)
        {
            GameObject moduleView = Instantiate(moduleViewTemplate, moduleViewContainer, false);
            moduleView.GetComponent<Button>().onClick.AddListener(() => OnButtonClicked(moduleType));
            moduleView.GetComponent<Image>().sprite = moduleType.GetComponent<SpriteRenderer>().sprite;
        }
    }

    public bool Open(Transform destination)
    {
        if (this.isActiveAndEnabled) return false;

        this.destination = destination;
        gameObject.SetActive(true);
        clickBlocker.SetActive(true);
        return true;
    }

    private void OnButtonClicked(Module moduleType)
    {
        Instantiate(moduleType, destination);
        gameObject.SetActive(false);
        clickBlocker.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
