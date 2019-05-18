using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject bulletPrefab;

    int bulletLayer; // stores which layer 'bullet' is in unity
    float attackCooldown;


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
    [SerializeField] float laserFireTime = 2f;
    [SerializeField] float laserOffTime = 2f;
    float laserCooldown;

    Transform gun;

	// Start is called before the first frame update
    void Start() {
    	bulletLayer = gameObject.layer; // layer in unity should be set to bullet
    	attackCooldown = 0f;
        laserCooldown = laserFireTime;
    }

    // Update is called once per frame
    void Update() {  
        if (!laser) {
            attackCooldown -= Time.deltaTime;
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
            if (laserCooldown >= 0) { // fires laser for this amount of time
                FireLaser();
            }
            else { // laser stops firing for this amount of time
                laserCooldown -= Time.deltaTime;
                if (laserCooldown < -laserOffTime) {
                    laserCooldown = laserFireTime;
                }
            }

        }   
    }

    void FireLaser() {
        Quaternion rot = Quaternion.Euler(0, 0, angleOffset); // sets bullet rotation
        bullet = (GameObject)Instantiate(bulletPrefab, gameObject.transform.position, rot * transform.rotation); 
        bullet.layer = bulletLayer;  // sets gameObject to bullet
        bullet.GetComponent<BulletTrajectoryLinear>().speed = speed; // sets speed for <BulletTrajectoryLinear>
        bullet.GetComponent<BulletTrajectoryLinear>().damage = damage; // sets damage for <BulletTrajectoryLinear>
        laserCooldown -= Time.deltaTime;
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
