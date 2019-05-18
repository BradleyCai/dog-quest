using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageTaker : MonoBehaviour
{
    public string damageTypeTag;
    public int maxHealth = 10;
    public Slider bloodbar;

    private int health;

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

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == damageTypeTag) {
            health -= other.gameObject.GetComponent<BulletTrajectoryLinear>().damage;
            //GameObject.Destroy(other.gameObject);
        }
    }
}
