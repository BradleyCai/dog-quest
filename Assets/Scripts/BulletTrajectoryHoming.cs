using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrajectoryHoming : MonoBehaviour {

	Transform player;

	[SerializeField] float rotationSpeed = 90f;

    // Update is called once per frame
    void Update() {
        if (player == null) {
        	GameObject target = GameObject.Find("BasicPlayer"); 

        	if (target != null) {
        		player = target.transform;
        	}
        }

        if (player == null) {
        	return;
        }

    	Vector3 direction = player.position - transform.position; // distance vector
        direction.Normalize();
        float zAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;

        Quaternion desiredRotation = Quaternion.Euler(0, 0, zAngle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);    
    }
}
