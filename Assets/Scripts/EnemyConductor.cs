using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyConductor : MonoBehaviour
{
    public GameObject[] enemies;
    public float spawnRate;

    private float time;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 1 / spawnRate) {
            time = 0;
            Instantiate(enemies[0], gameObject.transform.position, transform.rotation); 
        }
        time += Time.deltaTime;
    }
}
