using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngledGuns : MonoBehaviour
{
    public List<GameObject> guns;

    private List<float> angles = new List<float>();
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < guns.Count; i++)
        {
            angles.Add(guns[i].GetComponent<Shooter>().angleOffset);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale != 0.0f)
        {
            for (int i = 0; i < guns.Count; i++)
            {
                guns[i].GetComponent<Shooter>().enabled = true;
            }
        }
        else
        {
            for (int i = 0; i < guns.Count; i++)
            {
                guns[i].GetComponent<Shooter>().enabled = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            for (int i = 0; i < guns.Count; i++)
            {
                guns[i].GetComponent<Shooter>().angleOffset = 0;
            }
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            for (int i = 0; i < guns.Count; i++)
            {
                guns[i].GetComponent<Shooter>().angleOffset = angles[i];
            }
        }
    }
}
