using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffect : MonoBehaviour
{
    public enum Effect { Ammo, ShotSpeed, Damage, NULL};

    public Effect effect;

    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponentInChildren<Renderer>();

        switch(effect)
        {
            case Effect.Ammo:
                rend.material.color = Color.blue;
                break;
            case Effect.ShotSpeed:
                rend.material.color = Color.green;
                break;
            case Effect.Damage:
                rend.material.color = Color.red;
                break;
            case Effect.NULL:
                rend.material.color = Color.grey;
                break;
            default:
                rend.material.color = Color.grey;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
