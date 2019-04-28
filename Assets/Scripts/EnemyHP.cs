using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    private int maxHealth;
    private int health;
    public Slider bloodbar;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 1000;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //Damage:in the well finished demo,there shoule be corresponded with the OnTriggerEnter()
        health--;
        bloodbar.value = (float)health / maxHealth;

        if (health <= 0)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
