using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMovement : MonoBehaviour
{
    private Rigidbody rb;

    public float speed;
    public float disperseSpeed;

    private float timeSeg1; // this variable tells the script how long to "disperse" the item
    private float timeSeg2; // this variable tells the script how long to accelerate to top speed after the direction changes
    public float segRangeMin, segRangeMax;
    private float time;

    private bool yOnly;

    private Vector3 initialVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        yOnly = false;
        time = 0;
        timeSeg1 = Random.Range(segRangeMin, segRangeMax);
        timeSeg2 = Random.Range(1.0f, 2.0f);

        rb.velocity = initialVelocity = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0).normalized * disperseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (time < timeSeg1 && !yOnly)
        {
            rb.velocity = Vector3.Lerp(initialVelocity, Vector3.zero, time / timeSeg1);
        }
        else if (time >= timeSeg1 && !yOnly)
        {
            yOnly = true;
            time = 0;
        }

        if (yOnly && time <= timeSeg2)
        {
            rb.velocity = Vector3.Lerp(Vector3.zero, Vector3.down * speed, time / timeSeg2);
        }

        time += Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
