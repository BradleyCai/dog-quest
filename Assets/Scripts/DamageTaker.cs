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

    private AudioClip deadClip;
    private AudioClip collisonClip;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        deadClip = (AudioClip)Resources.Load("Sound Effects/death1", typeof(AudioClip));
        collisonClip = (AudioClip)Resources.Load("Sound Effects/stone_collision", typeof(AudioClip));
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
                AudioSource.PlayClipAtPoint(collisonClip, transform.position);
                //GameObject.Destroy(other.gameObject);
            }
        }
    }
}
