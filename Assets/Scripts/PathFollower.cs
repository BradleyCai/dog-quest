using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PathFollower : MonoBehaviour {
    public LineRenderer path; // path the follower should follow in the form of a LineRenderer GameObject
    public float duration; // how long the path follow should take in seconds
    public float angularSpeed;
    public bool loop = false;
    public Vector3 offset;

    private Vector3[] positions; // array of positions from the line renderer
    private Vector3[] segVectors; // array of segments represented as vectors
    private int segIndex; // the current segment the follower is on
    private float segDuration; // how long each path segment should take in seconds
    private float time; // how long the follower has been traveling
    private float segTime; // how long the follower has been traveling this segment
    private float pathLength; // total length of the path

    void resetFollower() {
        segIndex = 0;
        time = 0;
        segTime = 0;
        transform.position = positions[0] + offset + path.transform.position;
        segDuration = duration * (segVectors[segIndex].magnitude / pathLength);
    }

    void Start() {
        if (path.positionCount < 2) {
            return;
        }

        positions = new Vector3[path.positionCount];
        segVectors = new Vector3[path.positionCount];
        path.GetPositions(positions);

        for (int i = 0; i < segVectors.Length - 1; i++) {
            segVectors[i] = positions[i + 1] - positions[i];
            pathLength += segVectors[i].magnitude;
        }

        resetFollower();
    }

    void Update() {
        transform.Rotate(0, 0, angularSpeed);

        // travel each segment, updating the current segment as we go along
        if (segTime < segDuration) {
            transform.position += (Time.deltaTime / segDuration) * segVectors[segIndex];
            segTime += Time.deltaTime;
        }
        else {
            if (time + segTime < duration) {
                segIndex++;
                segDuration = duration * (segVectors[segIndex].magnitude / pathLength);
                time += segTime;
                segTime = 0;
            }
            else if (loop) {
                resetFollower();
            }
        }
    }
}
