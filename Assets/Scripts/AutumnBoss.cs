using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutumnBoss : MonoBehaviour
{
    private Transform t;
    private Vector3 size;
    private float xBoundary;
    private float yBoundary;
    private float xOffset;

    private int xDirection;
    private int yDirection;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Transform>();
        size.x = GetComponentInChildren<BoxCollider>().size.x * t.localScale.x;
        size.y = GetComponentInChildren<BoxCollider>().size.y * t.localScale.y;

        yBoundary = Camera.main.orthographicSize - size.y / 2.0f;
        xBoundary = Camera.main.orthographicSize - size.x / 2.0f;
        xOffset = Camera.main.orthographicSize / 3.0f;

        xDirection = Random.Range(-1, 1);
        if (xDirection == 0)
        {
            xDirection = 1;
        }
        yDirection = Random.Range(-1, 1);
        if (yDirection == 0)
        {
            yDirection = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        t.position += new Vector3(xDirection * speed, yDirection * speed, 0) * Time.deltaTime;
        
        if (t.position.x >= xBoundary - xOffset || t.position.x <= -xBoundary - xOffset)
        {
            t.position = new Vector3((xDirection * xBoundary) - xOffset, t.position.y, 0);
            xDirection *= -1;
        }
        if (t.position.y >= yBoundary || t.position.y <= -yBoundary)
        {
            t.position = new Vector3(t.position.x, yDirection * yBoundary, 0);
            yDirection *= -1;
        }
    }
}
