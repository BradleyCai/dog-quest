using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject bulletPrefab;

    int bulletLayer; // stores which layer 'bullet' is in unity
    float attackCooldown;



    /** basic linear attacks **/
    [Header("Basic Bullet (default)")]
    public float attackRate = 0.5f;
    [SerializeField] float angleOffset = 0;
    public float speed = 1;
    public int damage = 1;
    GameObject bullet;

    [Header("Homing Bullets")]
    [SerializeField] bool homing = false;
    [SerializeField] float rotationSpeed = 0f;

    [Header("Laser")]
    [SerializeField] bool laser = false;
    [SerializeField] bool homingLaser = false;
    [SerializeField] float laserFireTime = 2f;
    [SerializeField] float laserOffTime = 2f;
    bool fired = false;
    float laserCooldown;

    Quaternion rot;
    Transform gun;
    Transform player;

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
                if (homingLaser && laser) { // homing laser
                    FireHomingLaser();
                }
                else { // strait lasers
                    FireLaser();
                }
            }
            else { // laser stops firing for this amount of time
                laserCooldown -= Time.deltaTime;
                if (laserCooldown < -laserOffTime) {
                    laserCooldown = laserFireTime;
                }
                fired = false;
            }

        }   
    }

    void FireHomingLaser() {
        if (homingLaser) {
            if (!fired) {
                // Player just spawned, find player ship
                if (player == null) {
                    /*** change the string for player gameobject if player gets renamed ***/
                    GameObject target = GameObject.Find("BasicPlayer"); 

                    // found the player
                    if (target != null) {
                        player = target.transform;
                    }
                }

                // Player doesn't exist in this frame, move to next frame
                if (player == null) {
                    return;
                }

                // calculate distance vector
                Vector3 direction = player.position - transform.position;
                direction.Normalize(); 
                // calculate rotation toward player
                float zAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90; 
                // convert rotation angle to quaternions
                Quaternion desiredRotation = Quaternion.Euler(0, 0, zAngle);
                // set rotation toward player
                transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);

                rot = desiredRotation;
                fired = true;
            }
        }

        bullet = (GameObject)Instantiate(bulletPrefab, gameObject.transform.position, rot * transform.rotation); 
        bullet.layer = bulletLayer;  // sets gameObject to bullet
        bullet.GetComponent<BulletTrajectoryLinear>().speed = speed; // sets speed for <BulletTrajectoryLinear>
        bullet.GetComponent<BulletTrajectoryLinear>().damage = damage; // sets damage for <BulletTrajectoryLinear>
        laserCooldown -= Time.deltaTime;
    }

    void FireLaser() {
        rot = Quaternion.Euler(0, 0, angleOffset);
        bullet = (GameObject)Instantiate(bulletPrefab, gameObject.transform.position, rot * transform.rotation); 
        bullet.layer = bulletLayer;  // sets gameObject to bullet
        bullet.GetComponent<BulletTrajectoryLinear>().speed = speed; // sets speed for <BulletTrajectoryLinear>
        bullet.GetComponent<BulletTrajectoryLinear>().damage = damage; // sets damage for <BulletTrajectoryLinear>
        laserCooldown -= Time.deltaTime;
    }

    void BasicAttack() {
        attackCooldown = 1 / attackRate; // just fired, reset cooldown

        rot = Quaternion.Euler(0, 0, angleOffset); // sets bullet rotation
        bullet = (GameObject)Instantiate(bulletPrefab, gameObject.transform.position, rot * transform.rotation); 
        bullet.layer = bulletLayer;  // sets gameObject to bullet
        bullet.GetComponent<BulletTrajectoryLinear>().speed = speed; // sets speed for <BulletTrajectoryLinear>
        bullet.GetComponent<BulletTrajectoryLinear>().damage = damage; // sets damage for <BulletTrajectoryLinear>
    }
}
