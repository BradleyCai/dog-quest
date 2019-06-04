using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrajectoryHoming : MonoBehaviour {

	Transform origin;
    Transform target;
    GameObject targetObj;

    public string[] targetTags;

	[HideInInspector] public float rotationSpeed; // this value is set in Shooter, located in gun prefab
	[HideInInspector] public float angleOffset; // this value is set in Shooter, located in gun prefab

    void Start() {
        if (!UpdateNearestEnemy())
            return;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, GetRotationToEnemy(), 360);
        transform.rotation *= Quaternion.Euler(0, 0, angleOffset);
    }

    // Update is called once per frame
    void Update() {
        if (!UpdateNearestEnemy())
            return;

        // set rotation toward target
        transform.rotation = Quaternion.RotateTowards(transform.rotation, GetRotationToEnemy(), rotationSpeed * Time.deltaTime);
    }

    private Quaternion GetRotationToEnemy() {
    	Vector3 direction = target.position - transform.position;
        direction.Normalize(); 
        // calculate rotation toward target
        float zAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90; 

        // convert rotation angle to quaternions
        return Quaternion.Euler(0, 0, zAngle);;
    }

    // Returns true if nearest enemy found and updated, and false if not
    private bool UpdateNearestEnemy() {
        targetObj = FindNearestEnemy(); 
        if (targetObj == null)
        	return false;

        target = targetObj.transform;
        return true;
    }

    private GameObject FindNearestEnemy()
    {
        GameObject[] objects;
        GameObject targetObject;
        float distance = Mathf.Infinity;
        float objectDistance = 0.0f;
        targetObject = null;


        for (int j = 0; j < targetTags.Length; j++)
        {
            objects = GameObject.FindGameObjectsWithTag(targetTags[j]);

            for (int i = 0; i < objects.Length; i++)
            {
                objectDistance = (objects[i].transform.position - transform.position).sqrMagnitude;

                if (objectDistance < distance)
                {
                    distance = objectDistance;
                    targetObject = objects[i];
                }
            }
        }
        return targetObject;
    }
}
