using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject bulletPrefab;

    int bulletLayer; // stores which layer 'bullet' is in unity
    float attackCooldown;
    float laserCooldown;

    /** basic linear attacks **/
    [Header("Basic Bullet (default)")]
    [SerializeField] float attackRate = 0.5f;
    [SerializeField] float angleOffset = 0;
    [SerializeField] float speed = 1;
    [SerializeField] int damage = 1;
    GameObject bullet;

    [Header("Homing Bullets")]
    [SerializeField] bool homing = false;
    [SerializeField] float rotationSpeed = 0f;

    [Header("Laser")]
    [SerializeField] bool laser = false;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] float laserFireRate = 2f;
    float laserTimer = 2f;
    float laserTracking = 0f;
    float laserOn = 0f;

    Transform gun;

	// Start is called before the first frame update
    void Start() {
    	bulletLayer = gameObject.layer; // layer in unity should be set to bullet
    	attackCooldown = 0f;
        laserTracking = laserTimer;
    }

    // Update is called once per frame
    void Update() {  
        attackCooldown -= Time.deltaTime;   		
        laserCooldown -= Time.deltaTime;

        if (!laser) {
            // can attack again, FIRE!!!!
        	if (attackCooldown <= 0) {
            	BasicAttack();
                
                // if the bullet is homing, set "homing" effectiveness 
                if (homing) {
                    bullet.GetComponent<BulletTrajectoryHoming>().rotationSpeed = rotationSpeed; // sets the roation sepped for <BulletTrajectoryHoming>
                }
            }
        }
        // attack with laser
        if (laser) {
            FireLaser();
        }   
    }

    void FireLaser() {
        laserTracking -= Time.deltaTime;
        laserOn -= Time.deltaTime;
        GameObject target = GameObject.Find("BasicPlayer");  
        lineRenderer.SetPosition(0, gameObject.transform.position);
        float laserOffset = 0.5f;

        if (!lineRenderer.enabled) {
            lineRenderer.enabled = true;
            lineRenderer.SetWidth(0.03f, 0.03f);
        }

        if (laserCooldown <= 0) {

            if (laserTracking <= 0) {
                laserCooldown = 1 / laserFireRate;
                
                Vector3 offsetPos = target.transform.position;
                if (gameObject.transform.position.x > target.transform.position.x) { 
                    offsetPos.x = target.transform.position.x + laserOffset;
                }
                else if (gameObject.transform.position.x < target.transform.position.x) {
                    offsetPos.x = target.transform.position.x - laserOffset;
                } 
                else {
                    offsetPos.x = target.transform.position.x;
                }      
                if (gameObject.transform.position.y > target.transform.position.y) { 
                    offsetPos.y = target.transform.position.y + laserOffset;
                }
                else if (gameObject.transform.position.y < target.transform.position.y) {
                    offsetPos.y = target.transform.position.y - laserOffset;
                }
                else {
                    offsetPos.y = target.transform.position.y;
                }

                lineRenderer.SetWidth(0.25f, 0.25f);
                lineRenderer.SetPosition(1, offsetPos);

                laserTracking = laserTimer; 
                laserOn = laserFireRate;
            }
        }

        if (laserOn <= 0) {
            lineRenderer.SetWidth(0.03f, 0.03f);
            lineRenderer.SetPosition(1, target.transform.position);
        }

    }

    void BasicAttack() {
        attackCooldown = 1 / attackRate; // just fired, reset cooldown

        Quaternion rot = Quaternion.Euler(0, 0, angleOffset); // sets bullet rotation
        bullet = (GameObject)Instantiate(bulletPrefab, gameObject.transform.position, rot * transform.rotation); 
        bullet.layer = bulletLayer;  // sets gameObject to bullet
        bullet.GetComponent<BulletTrajectoryLinear>().speed = speed; // sets speed for <BulletTrajectoryLinear>
        bullet.GetComponent<BulletTrajectoryLinear>().damage = damage; // sets damage for <BulletTrajectoryLinear>
    }
}
