using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("other: " + other.name);
        if (other.tag == "Item")
        {
            switch(other.gameObject.GetComponent<ItemEffect>().effect)
            {
                case ItemEffect.Effect.Ammo:
                    // Effect
                    Destroy(other.gameObject);
                    Debug.Log("Item Consumed: Ammo");
                    break;
                case ItemEffect.Effect.ShotSpeed:
                    // Effect
                    Destroy(other.gameObject);
                    Debug.Log("Item Consumed: ShotSpeed");
                    break;
                case ItemEffect.Effect.Damage:
                    // Effect
                    Destroy(other.gameObject);
                    Debug.Log("Item Consumed: Damage");
                    break;
                case ItemEffect.Effect.NULL:
                    Destroy(other.gameObject);
                    Debug.Log("Item Consumed: NULL");
                    break;
                default:
                    Destroy(other.gameObject);
                    Debug.Log("Item Consumed: Undefined");
                    break;
            }
        }
    }
}
