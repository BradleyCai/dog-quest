using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttackObject : MonoBehaviour
{
    private CircleCollider2D circle;

    public float radius;
    public float duration; // this is how long it takes for the circle to expand to the desired radius
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        circle = this.gameObject.GetComponent<CircleCollider2D>();
        circle.radius = 0.0f;

        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        circle.radius = radius * (time / duration);

        if (time >= duration)
        {
            Destroy(this.gameObject);
        }

        time += Time.deltaTime;
    }
}
