using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveFromPlay : MonoBehaviour {

    float offset = 2f;

    // Update is called once per frame
    void Update() {
    	Vector3 pos = transform.position;
        
        // outside y camera boundaries, remove from play
        if (pos.y > Camera.main.orthographicSize * offset || pos.y < -Camera.main.orthographicSize * offset) {
        	Destroy(gameObject);
        }

        // outside of x camera boundaries, remove from play
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;
        if (pos.x > widthOrtho * offset || pos.x < -widthOrtho * offset) {
            Destroy(gameObject);
        }
    }

}
