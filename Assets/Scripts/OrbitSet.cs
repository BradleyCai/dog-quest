using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitSet : MonoBehaviour
{
    public GameObject[] objects; // objects in the orbit set

    private bool destroyThis;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.name = "OrbitSet";
    }

    // Update is called once per frame
    void Update()
    {
        destroyThis = true;
        foreach (GameObject obj in objects)
        {
            if (obj != null)
            {
                destroyThis = false;
            }
        }

        if (destroyThis)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
