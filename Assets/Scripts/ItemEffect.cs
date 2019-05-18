using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffect : MonoBehaviour
{
    public enum Effect { Ammo, ShotSpeed, Damage, NULL};

    public Effect effect;
    public bool random;
    private int randomNum;

    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponentInChildren<Renderer>();

        randomNum = Random.Range(1, 4);

        if (random)
        {
            switch (randomNum)
            {
                case 1:
                    effect = Effect.ShotSpeed;
                    break;
                case 2:
                    effect = Effect.Damage;
                    break;
                case 3:
                    effect = Effect.Ammo;
                    break;
                default:
                    effect = Effect.NULL;
                    break;
            }
        }

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
