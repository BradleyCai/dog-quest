using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageTaker : MonoBehaviour
{
    public string damageTypeTag;
    public int maxHealth = 10;
    public Slider bloodbar;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        bloodbar.value = (float)health / maxHealth;

        if (health <= 0) {
            GameObject.Destroy(this.transform.parent.gameObject);
        }
    }

    void increaseHealth(int amount) {
        if (amount + health > maxHealth)
            health = maxHealth;
        else
            health += amount;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == damageTypeTag) {
            health -= other.gameObject.GetComponent<BulletTrajectoryLinear>().damage;
            if (other.gameObject.name != "LaserBullet(Clone)") {
                GameObject.Destroy(other.gameObject);
            }
        }
    }
}
