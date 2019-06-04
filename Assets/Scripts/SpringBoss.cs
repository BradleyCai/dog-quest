using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringBoss : MonoBehaviour
{
    private Transform bossTransform;
    private float initialX;
    public float width; // the amount of space the boss travels back and forth between
    public float bossSpeed;

    public float waitTimeTeleport;
    public float waitTimeFire;

    public float flowerShooterDelay;

    private float time;

    // Start is called before the first frame update
    void Start()
    {
        bossTransform = GameObject.Find("SpringBossModel").transform;
        initialX = bossTransform.position.x;

        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (time >= flowerShooterDelay)
        {
            GetComponentInChildren<SpringBossFlowerShooter>().enabled = true;
        }

        bossTransform.position = new Vector3(initialX + width * Mathf.Sin(bossSpeed * Time.time), transform.position.y, transform.position.z);
    }
}
