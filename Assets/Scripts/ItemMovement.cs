using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMovement : MonoBehaviour
{
    private Rigidbody rb;

    public float speed;
    public float disperseSpeedMultiplier;

    private float timeSeg; // this variable tells the script how long to "disperse" the item
    public float segRangeMin, segRangeMax;
    private float time;

    private bool yOnly;

    private Vector3 initialVelocity;
    private Vector3 finalVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        yOnly = false;
        time = 0;
        timeSeg = Random.Range(segRangeMin, segRangeMax);

        rb.velocity = initialVelocity = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0).normalized * speed * disperseSpeedMultiplier;
        finalVelocity = initialVelocity / disperseSpeedMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        if (time < timeSeg)
        {
            rb.velocity = Vector3.Lerp(initialVelocity, finalVelocity, time / timeSeg);
        }
        else if (time >= timeSeg && !yOnly)
        {
            ChangeVelocity();
        }

        time += Time.deltaTime;
    }

    void ChangeVelocity()
    {
        rb.velocity = new Vector3(0, -speed, 0);
        yOnly = true;
    }
}
