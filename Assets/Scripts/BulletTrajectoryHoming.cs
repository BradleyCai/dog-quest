using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrajectoryHoming : MonoBehaviour {

	Transform player;

	[SerializeField] float rotationSpeed = 90f; // change this value to make "homingness" more or less hard

    // Update is called once per frame
    void Update() {
    	
    	// Player just spawned, find player ship
        if (player == null) {
        	/*** change the string for player gameobject if player gets renamed ***/
        	GameObject target = GameObject.Find("BasicPlayer"); 

        	// found the player
        	if (target != null) {
        		player = target.transform;
        	}
        }

        // Player doesn't exist in this frame, move to next grame
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
    }
}
