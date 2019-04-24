using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public GameObject bulletPrefab;

    int bulletLayer; // stores which layer 'bullet' is in unity
    float attackCooldown;

    [SerializeField] float attackRate = 0.5f;
    [SerializeField] float attackAngle = 0;
    [SerializeField] float speed = 1;
    [SerializeField] float damage = 1f;

	// Start is called before the first frame update
    void Start() {
    	bulletLayer = gameObject.layer; // layer in unity should be set to bullet
    	attackCooldown = 0f;
    }

    // Update is called once per frame
    void Update() {  
        attackCooldown -= Time.deltaTime;        		

        // can attack again, FIRE!!!!
    	if (attackCooldown <= 0) {
    		attackCooldown = attackRate; // just fired, reset cooldown

			Quaternion rot = Quaternion.Euler(0, 0, attackAngle); // sets bullet rotation
            GameObject bullet = (GameObject)Instantiate(bulletPrefab, gameObject.transform.position, rot); 
            bullet.layer = bulletLayer;  // sets gameObject to bullet
            bullet.GetComponent<BulletTrajectoryLinear>().speed = speed; // sets speed for <BulletTrajectoryLinear>
    	}
    }
}
