using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PathFollower : MonoBehaviour {
    public LineRenderer path; // path the follower should follow in the form of a LineRenderer GameObject
    public float speed;
    public float delay; // how long until the path follow starts
    public Vector3 offset;
    public bool loop = false;
    public int loopIndex;

    private Vector3[] positions; // array of positions from the line renderer
    private int nextNode;

    void Start() {
        nextNode = 1;
        positions = new Vector3[path.positionCount];
        path.GetPositions(positions);

        for (int i = 0; i < positions.Length; i++) {
            positions[i] += path.transform.position + offset;
        }

        transform.position = positions[0];
    }

    void Update() {
        if (nextNode < positions.Length) {
            transform.position = Vector3.MoveTowards(transform.position, positions[nextNode], speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, positions[nextNode]) < 0.001f) {
                ++nextNode;
            }
        }
        else {
            if (loop)
                nextNode = loopIndex;
            else
                this.enabled = false;
        }
    }
}
