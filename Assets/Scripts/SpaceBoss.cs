using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBoss : MonoBehaviour
{
    public float spawnDelay; // variable for setting the time between spawns
    private float time;

    public GameObject orbitSet;

    public GameObject shield;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("OrbitSet") == null)
        {
            shield.SetActive(false);
            if (time >= spawnDelay)
            {
                shield.SetActive(true);
                time = 0;
                Instantiate(orbitSet, transform);
            }
            time += Time.deltaTime;
        }

        if (GameObject.Find("OrbitSet") != null)
        {
            shield.SetActive(true);
        }
    }
}
