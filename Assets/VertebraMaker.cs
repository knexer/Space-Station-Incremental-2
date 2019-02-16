using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertebraMaker : MonoBehaviour
{
    [SerializeField] private GameObject vertebraTemplate;
    [SerializeField] private int numVertebrae;

    // Start is called before the first frame update
    private void Start()
    {
        Vector2 step = Vector2.right * vertebraTemplate.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        Vector2 start = (Vector2) transform.position - step * numVertebrae / 2f;
        for (int i = 0; i < numVertebrae; i++)
        {
            GameObject vertebra = Instantiate(vertebraTemplate);
            vertebra.transform.position = start + step * i;
        }
    }
}
