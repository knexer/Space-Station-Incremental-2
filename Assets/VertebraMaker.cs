using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertebraMaker : MonoBehaviour
{
    [SerializeField] private GameObject vertebraTemplate;
    [SerializeField] private GameObject addVertebraClickbox;
    [SerializeField] private int startingNumVertebrae;
    private int numVertebrae;

    private Vector2 NextPosition => numVertebrae *
                                    Vector2.right *
                                    vertebraTemplate.GetComponent<SpriteRenderer>().sprite.bounds.size.x;

    // Start is called before the first frame update
    private void Start()
    {
        for (int i = 0; i < startingNumVertebrae; i++)
        {
            AddVertebra();
        }
    }

    public void AddVertebra()
    {
        GameObject vertebra = Instantiate(vertebraTemplate, transform);
        vertebra.transform.position = NextPosition;
        numVertebrae++;

        addVertebraClickbox.transform.position = NextPosition;
    }
}
