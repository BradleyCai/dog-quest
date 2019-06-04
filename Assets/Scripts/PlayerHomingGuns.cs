using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHomingGuns : MonoBehaviour
{
    public List<GameObject> guns;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && Time.timeScale != 0.0f)
        {
            for (int i = 0; i < guns.Count; i++)
            {
                guns[i].GetComponent<Shooter>().enabled = true;
            }
        }
        else if (Input.GetKeyUp(KeyCode.C))
        {
            for (int i = 0; i < guns.Count; i++)
            {
                guns[i].GetComponent<Shooter>().enabled = false;
            }
        }
    }
}
