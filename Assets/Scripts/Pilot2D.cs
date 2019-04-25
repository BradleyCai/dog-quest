using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilot2D : MonoBehaviour
{
    public float speed = 1;
    public float shiftSpeed = 0.5f;
    public Rigidbody rb;
    public Transform t;

    public List<Transform> sockets; 
    public float shotDelay;
    private float waitTime;
    private int shotsFired;

    public float xBoundary = 5.5f;
    public float yBoundary = 4.3f;

    public GameObject projectile;
    //private List<GameObject> projectiles = new List<GameObject>();
    //public int maxProjectiles;

    private int index;
    //private int index2 = 0;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = 0;
        shotsFired = 0;
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
        
        if (waitTime >= shotDelay && Input.GetKey(KeyCode.Space))
        {

            index = shotsFired % sockets.Count;
            /*
            if (projectiles.Count < maxProjectiles)
            {
                GameObject obj;
                obj = (GameObject) Instantiate(projectile, sockets[index].position, sockets[index].rotation);
                projectiles.Add(obj);
            }
            else
            {
                
                projectiles[index2].GetComponent<Transform>().SetPositionAndRotation(sockets[index].position, sockets[index].rotation);
            }
            */
            Instantiate(projectile, sockets[index].position, sockets[index].rotation);
            waitTime = 0;
            shotsFired++;
            //index2 = (index2 + 1) % maxProjectiles;
        }
        
        waitTime += Time.deltaTime;
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
