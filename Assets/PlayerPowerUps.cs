using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUps : MonoBehaviour
{
    public MonoBehaviour specialAttack;
    public MonoBehaviour angledGuns;
    public MonoBehaviour homingGuns;
    public MonoBehaviour shield;

    public enum Power { L1, L2, L3, L4, L5 };
    public Power p;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (p)
        {
            case Power.L1:
                specialAttack.enabled = false;
                angledGuns.enabled = false;
                homingGuns.enabled = false;
                shield.enabled = false;
                break;
            case Power.L2:
                specialAttack.enabled = true;
                angledGuns.enabled = false;
                homingGuns.enabled = false;
                shield.enabled = false;
                break;
            case Power.L3:
                specialAttack.enabled = true;
                angledGuns.enabled = true;
                homingGuns.enabled = false;
                shield.enabled = false;
                break;
            case Power.L4:
                specialAttack.enabled = true;
                angledGuns.enabled = true;
                homingGuns.enabled = true;
                shield.enabled = false;
                break;
            case Power.L5:
                specialAttack.enabled = true;
                angledGuns.enabled = true;
                homingGuns.enabled = true;
                shield.enabled = true;
                break;
            default:
                break;
        }
    }
}
