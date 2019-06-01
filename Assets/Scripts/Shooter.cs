using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject bulletPrefab; // skin of the bullet being fired

    int bulletLayer;                // stores which layer 'bullet' is in unity
    public float speed = 1;         // how fast a bullet travels
    public int damage = 1;          // how much damage a bullet does
    public float angleOffset = 0;   // the angle the bullet is fired from
    public float delay = 0;         // delay before the shooter starts shooting

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
      *
      * Default: rotationSpeed equals 0, so no homing ability
    **/
    [Header("Homing Bullets")]
    public bool homingBullet = false;
    public float rotationSpeed = 0f;

    /** Random Angle Attack: define angles in unity and fire a bullet with the random angle
      * randomAngle: bullet fires with a random angle
      * startAngle: start range for possible angles
      * stopAngle: end range for possible angles
      *
      * Default: startAngle and stopAngle equal 0 so they shoot straight
    **/
    [Header("Random Angle")]
    public bool randomAngle = false;
    public float startAngle = 0f;
    public float stopAngle = 0f;

    /** Laser Attack: fires a laser linearly 
      * laser: selection on unity menu to set enemy to fire lasters
      * laserFireTime: length of time laser is fired
      * laserOffTime: length of time laser does not fire
    **/
    [Header("Laser")]
    public bool laser = false;
    public float laserFireTime = 2f;
    public float laserOffTime = 2f;
    float laserCooldown;

    /** Homing Laser Attack: fires a laser linearly towards a target
      * laser: selection on unity menu to set enemy to fire lasters
      * laserFireTime: length of time laser is fired
      * laserOffTime: length of time laser does not fire
    **/
    [Header("Homing Laser")]
    public bool homingLaser = false;
    public float laserHomingFireTime = 2f;
    public float laserHomingOffTime = 2f;
    float laserHomingCooldown;

    Quaternion rot;
    Transform gun;
    Transform player;
    GameObject bullet; 
    bool fired;

    // Start is called before the first frame update
    public void Start() {
        bulletLayer = gameObject.layer; // layer in unity should be set to bullet
        attackCooldown = delay;
        laserCooldown = laserFireTime;
        laserHomingCooldown = laserHomingFireTime;
        fired = false;
    }

    // Update is called once per frame
    void Update() {  
        /** Default attack **/
        if (!laser && !homingLaser && !randomAngle) {
            attackCooldown -= Time.deltaTime;
            // can attack again, FIRE!!!!
            if (attackCooldown <= 0) {
                BasicAttack();
                
                // if the bullet is homing, set "homing" effectiveness 
                if (homingBullet) {
                    bullet.GetComponent<BulletTrajectoryHoming>().rotationSpeed = rotationSpeed; // sets the roation sepped for <BulletTrajectoryHoming>
                }
            }
        }

        /* fires bullets at random angles set by user */
        if (randomAngle) {
            attackCooldown -= Time.deltaTime;
            // can attack again, FIRE!!!!
            if (attackCooldown <= 0) {
                RandomAngleAttack();
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
        if (!fired) { // sets homing direction once
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

    void RandomAngleAttack() {
        attackCooldown = 1 / attackRate; // just fired, reset cooldown

        angleOffset = Random.Range(startAngle, stopAngle);
        rot = Quaternion.Euler(0, 0, angleOffset); // sets bullet rotation
        bullet = (GameObject)Instantiate(bulletPrefab, gameObject.transform.position, rot * transform.rotation); 
        bullet.layer = bulletLayer;  // sets gameObject to bullet
        bullet.GetComponent<BulletTrajectoryLinear>().speed = speed; // sets speed for <BulletTrajectoryLinear>
        bullet.GetComponent<BulletTrajectoryLinear>().damage = damage; // sets damage for <BulletTrajectoryLinear>
    }

    void BasicAttack() {
        rot = Quaternion.Euler(0, 0, angleOffset) * transform.rotation; // sets bullet rotation
        attackCooldown = 1 / attackRate; // just fired, reset cooldown
        bullet = (GameObject)Instantiate(bulletPrefab, gameObject.transform.position, rot);
        bullet.layer = bulletLayer;  // sets gameObject to bullet
        bullet.GetComponent<BulletTrajectoryLinear>().speed = speed;// + projMag; // sets speed for <BulletTrajectoryLinear>
        bullet.GetComponent<BulletTrajectoryLinear>().damage = damage; // sets damage for <BulletTrajectoryLinear>
    }
}
