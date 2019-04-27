using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    private Vector3 vel;
    public float speed = 1;

    private Transform t;

    public int maxHealth;
    public int health;
    public Slider bloodbar;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 1000;
        health = 1000;
        t = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Damage
        health--;
        bloodbar.value = (float)health / maxHealth;

        if (health <= 0)
        {
            GameObject.Destroy(this.gameObject);
        }

        // Movement

        vel = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0.0f);
        
        t.position += Time.deltaTime * speed * vel;
    }
}
