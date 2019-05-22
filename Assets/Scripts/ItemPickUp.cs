using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    private List<GameObject> list;

    [SerializeField] int damageBoost = 1;
    [SerializeField] int healthBoost = 1;
    [SerializeField] int ammoBoost = 1;
    [SerializeField] float attackRateBoost = 1;
    [SerializeField] float attackSpeedBoost = 1;
    // Start is called before the first frame update
    void Start()
    {
        list = GetComponentInParent<PlayerController>().guns;
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
                    if (GetComponent<SpecialAttack>().ammo < GetComponent<SpecialAttack>().ammoMax)
                    {
                        GetComponent<SpecialAttack>().ammo += ammoBoost;
                        if (GetComponent<SpecialAttack>().ammo > GetComponent<SpecialAttack>().ammoMax)
                        {
                            GetComponent<SpecialAttack>().ammo = GetComponent<SpecialAttack>().ammoMax;
                        }
                    }

                    
                    Destroy(other.gameObject);

                    Debug.Log("Item Consumed: Ammo");
                    break;
                case ItemEffect.Effect.Health:
                    // for (int i = 0; i < list.Count; i++)
                    // {
                        // list[i].GetComponent<Shooter>().attackRate += attackRateBoost;
                        // list[i].GetComponent<Shooter>().speed += attackSpeedBoost;
                    // }

                    this.BroadcastMessage("increaseHealth", healthBoost);

                    Destroy(other.gameObject);

                    Debug.Log("Item Consumed: Health");
                    break;
                case ItemEffect.Effect.Damage:
                    for (int i = 0; i < list.Count; i++)
                    {
                        list[i].GetComponent<Shooter>().damage += damageBoost;
                    }
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
