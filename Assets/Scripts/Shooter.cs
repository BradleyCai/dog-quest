using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject bulletPrefab; // skin of the bullet being fired
    int bulletLayer;                // stores which layer 'bullet' is in unity
    public float speed = 1;         // how fast a bullet travels
    public int damage = 1;          // how much damage a bullet does
    public float angleOffset = 0;   // the angle the bullet is fired from

    /** Basic Linear Attack (default): fires straight 
      * If nothing is selected, this is used as default
      * attackRate: how fast the gun fires
      * attackCooldown: used to reset fire rate when gun has fired
    **/
    [Header("Basic Bullet (default)")]
    public float attackRate = 0.5f;
    float attackCooldown = 0f;

    /** Homing Bullet Attack: fires towards target
      * homing: selection on unity menu to set enemy to fire bullets to track target
      * rotationSpeed: how much the bullet can rotate towards the target
    **/
    [Header("Homing Bullets")]
    [SerializeField] bool homing = false;
    [SerializeField] float rotationSpeed = 0f;

    /** Laser Attack: fires a laser linearly 
      * laser: selection on unity menu to set enemy to fire lasters
      * laserFireTime: length of time laser is fired
      * laserOffTime: length of time laser does not fire
    **/
    [Header("Laser")]
    [SerializeField] bool laser = false;
    [SerializeField] float laserFireTime = 2f;
    [SerializeField] float laserOffTime = 2f;
    float laserCooldown;

    /** Homing Laser Attack: fires a laser linearly towards a target
      * laser: selection on unity menu to set enemy to fire lasters
      * laserFireTime: length of time laser is fired
      * laserOffTime: length of time laser does not fire
    **/
    [Header("Homing Laser")]
    [SerializeField] bool homingLaser = false;
    [SerializeField] float laserHomingFireTime = 2f;
    [SerializeField] float laserHomingOffTime = 2f;
    float laserHomingCooldown;

    Quaternion rot;
    Transform gun;
    Transform player;
    GameObject bullet; 
    bool fired;

    // Start is called before the first frame update
    void Start() {
        bulletLayer = gameObject.layer; // layer in unity should be set to bullet
        attackCooldown = 0f;
        laserCooldown = laserFireTime;
        laserHomingCooldown = laserHomingFireTime;
        fired = false;
    }

    // Update is called once per frame
    void Update() {  
        /** Default attack **/
        if (!laser && !homingLaser) {
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

        /* Basic Laser Attack */
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

        /* Homing Laser Attack */
        if (homingLaser) {
            if (laserHomingCooldown >= 0) { // fires laser for this amount of time
                //Debug.Log("firing");
                FireHomingLaser();
            }
            else { // laser stops firing for this amount of time
                laserHomingCooldown -= Time.deltaTime;
                if (laserHomingCooldown < -laserHomingOffTime) {
                    laserHomingCooldown = laserHomingFireTime;
                }
                fired = false;
            }
        }  

    }

    void FireHomingLaser() {
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

        bullet = (GameObject)Instantiate(bulletPrefab, gameObject.transform.position, rot * transform.rotation); 
        bullet.layer = bulletLayer;  // sets gameObject to bullet
        bullet.GetComponent<BulletTrajectoryLinear>().speed = speed; // sets speed for <BulletTrajectoryLinear>
        bullet.GetComponent<BulletTrajectoryLinear>().damage = damage; // sets damage for <BulletTrajectoryLinear>
        laserHomingCooldown -= Time.deltaTime;
        
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
