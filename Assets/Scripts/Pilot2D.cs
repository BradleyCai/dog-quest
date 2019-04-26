using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilot2D : MonoBehaviour
{
    private Vector3 vel;
    public float speed = 1;
    public float shiftSpeed = 0.5f;

    private Transform t;

    public List<GameObject> guns; // manually add the guns added to the player to this list

    private float xBoundary;
    private float yBoundary;

    private Vector2 playerSize;

    // Start is called before the first frame update
    void Start()
    {
        t = this.GetComponent<Transform>();
        playerSize.x = GetComponent<BoxCollider>().size.x;
        playerSize.y = GetComponent<BoxCollider>().size.y;
        yBoundary = Camera.main.orthographicSize - playerSize.y / 2.0f;
        xBoundary = Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height) - playerSize.x / 2.0f;
    }

    // Update is called once per frame
    void Update()
    {

        // Movement

        vel = new Vector3 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0.0f);
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            t.position += Time.deltaTime * shiftSpeed * vel;
        }
        else
        {
            t.position += Time.deltaTime * speed * vel;
        }
        
        // Boundaries

        if (t.position.x > xBoundary)
        {
            t.position = new Vector3(xBoundary, t.position.y, t.position.z);
        }
        if (t.position.x < -xBoundary)
        {
            t.position = new Vector3(-xBoundary, t.position.y, t.position.z);
        }
        if (t.position.y > yBoundary)
        {
            t.position = new Vector3(t.position.x, yBoundary, t.position.z);
        }
        if (t.position.y < -yBoundary)
        {
            t.position = new Vector3(t.position.x, -yBoundary, t.position.z);
        }

        // Firing
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < guns.Count; i++)
            {
                guns[i].GetComponent<Shooter>().enabled = true; // enables Shooter Script on guns
            }
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            for (int i = 0; i < guns.Count; i++)
            {
                guns[i].GetComponent<Shooter>().enabled = false; // disables Shooter Script on guns
            }
        }
    }
}
