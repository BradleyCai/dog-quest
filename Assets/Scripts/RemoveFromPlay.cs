using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveFromPlay : MonoBehaviour {

    // Update is called once per frame
    void Update() {
    	Vector3 pos = transform.position;

        // outside y camera boundaries, remove from play
        if (pos.y > Camera.main.orthographicSize || pos.y < -Camera.main.orthographicSize) {
        	Destroy(gameObject);
        }

        // outside of x camera boundaries, remove from play
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;
        if (pos.x > widthOrtho || pos.x < -widthOrtho) {
            Destroy(gameObject);
        }
    }

}
