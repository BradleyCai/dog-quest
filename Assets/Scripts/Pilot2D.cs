using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilot2D : MonoBehaviour
{
    public float speed = 1;
    public float shiftSpeed = 0.5f;
    private Rigidbody rb;
    private Transform t;
    public List<GameObject> guns; // manually add the guns added to the player to this list

    public float xBoundary = 5.5f;
    public float yBoundary = 4.3f;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>(); // Don't forget to add a Rigidbody component to the object!
        t = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        // Movement

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                rb.velocity = new Vector3(-shiftSpeed, rb.velocity.y, 0);
            }
            else
            {
                rb.velocity = new Vector3(-speed, rb.velocity.y, 0);
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                rb.velocity = new Vector3(shiftSpeed, rb.velocity.y, 0);
            }
            else
            {
                rb.velocity = new Vector3(speed, rb.velocity.y, 0);
            }
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                rb.velocity = new Vector3(rb.velocity.x, shiftSpeed, 0);
            }
            else
            {
                rb.velocity = new Vector3(rb.velocity.x, speed, 0);
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow)) {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                rb.velocity = new Vector3(rb.velocity.x, -shiftSpeed, 0);
            }
            else
            {
                rb.velocity = new Vector3(rb.velocity.x, -speed, 0);
            }
        }
        else { rb.velocity = new Vector3(rb.velocity.x, 0, 0); }

        // Boundaries

        if (t.position.x > xBoundary) { t.SetPositionAndRotation(new Vector3(xBoundary, t.position.y, t.position.z), t.rotation); }
        if (t.position.x < -xBoundary) { t.SetPositionAndRotation(new Vector3(-xBoundary, t.position.y, t.position.z), t.rotation); }
        if (t.position.y > yBoundary) { t.SetPositionAndRotation(new Vector3(t.position.x, yBoundary, t.position.z), t.rotation); }
        if (t.position.y < -yBoundary) { t.SetPositionAndRotation(new Vector3(t.position.x, -yBoundary, t.position.z), t.rotation); }

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Friendly Projectile")
        {
            // player destroyed
            // play destruction animation/create particle effect
            GameObject.Destroy(this.gameObject);
        }
    }
}
