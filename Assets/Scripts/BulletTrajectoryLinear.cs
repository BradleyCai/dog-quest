using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrajectoryLinear : MonoBehaviour {

	public float speed; // this value is set in EnemyAttack, located in gun prefab
	public int damage; // this value is set in EnemyAttack, located in gun prefab

    public string targetTag;

    // Update is called once per frame
    void Update() {
        Vector3 pos = transform.position; 							  // current position of the game object
        Vector3 velocity = new Vector3(0, speed * Time.deltaTime, 0); // speed set in EnemyAttack

        pos += transform.rotation * velocity; 						  // calculate next position based on rotation and speed
        transform.position = pos; 									  // set bullet's next position
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == targetTag)
        {
            Destroy(this.gameObject);
        }
    }
}
