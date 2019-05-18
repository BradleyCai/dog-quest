using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public GameObject item;
    public int minItems;
    public int maxItems;
    private int numItems;
    private Transform t;

    // Start is called before the first frame update
    void Start()
    {
        numItems = Random.Range(minItems, maxItems);
        t = GetComponent<Transform>();
    }

    private void OnDestroy()
    {
        for (int i = 0; i < numItems; i++)
        {
            Instantiate(item, t.position, t.rotation);
        }
    }
}
