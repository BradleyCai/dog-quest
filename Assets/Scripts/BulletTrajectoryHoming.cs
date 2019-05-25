using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrajectoryHoming : MonoBehaviour {

	Transform origin;
    Transform target;
    public string targetTag;

	[HideInInspector] public float rotationSpeed; // this value is set in Shooter, located in gun prefab

    // Update is called once per frame
    void Update() {
    	
    	// Player just spawned, find player ship
        if (target == null) {
            /*** change the string for player gameobject if player gets renamed ***/
            target = FindNearestEnemy().transform; 

        	// found the target
        }

        // Player doesn't exist in this frame, move to next frame
        if (target == null) {
        	return;
        }

        // calculate distance vector
    	Vector3 direction = target.position - transform.position;
        direction.Normalize(); 
        // calculate rotation toward target
        float zAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90; 
        // convert rotation angle to quaternions
        Quaternion desiredRotation = Quaternion.Euler(0, 0, zAngle);
        // set rotation toward target
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);    
    
    }

    private GameObject FindNearestEnemy()
    {
        GameObject[] objects;
        GameObject targetObject;


        objects = GameObject.FindGameObjectsWithTag(targetTag);
        targetObject = null;
        float distance = Mathf.Infinity;
        float objectDistance = 0.0f;

        for (int i = 0; i < objects.Length; i++)
        {
            objectDistance = (objects[i].transform.position - origin.position).sqrMagnitude;

            if (objectDistance < distance)
            {
                distance = objectDistance;
                targetObject = objects[i];
            }
        }

        return targetObject;
    }
}
