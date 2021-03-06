﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttackObject : MonoBehaviour
{
    private SphereCollider circle;
    private GameObject obj;

    public bool custom; // this value allows us to use custom values for the radius if on, otherwise it uses the screen width
    public bool projectilesOnly;
    public float radius;
    public float duration; // this is how long it takes for the circle to expand to the desired radius
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        circle = this.gameObject.GetComponentInParent<SphereCollider>();
        circle.radius = 0.0001f;

        obj = GameObject.Find("SpecialAttackSphere");

        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (custom)
        {
            circle.radius = radius * (time / duration);
            obj.GetComponentInParent<Transform>().localScale = new Vector3 (2 * circle.radius, 2 * circle.radius, 0);
        }
        else
        {
            circle.radius = 4 * Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height) * (time / duration);
            obj.GetComponentInParent<Transform>().localScale = new Vector3(2 * circle.radius, 2 * circle.radius, 0.1f);
        }

        if (time >= duration)
        {
            Destroy(this.gameObject);
        }

        time += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy Projectile")
        { 
            Destroy(other.gameObject);
        }
        if (other.tag == "Enemy" && !projectilesOnly)
        {
            Destroy(other.gameObject);
            Destroy(other.transform.parent.gameObject);
        }
    }
}
