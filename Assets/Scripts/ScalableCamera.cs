/*
 * Code inspired by unknown author from http://www.thegamecontriver.com/2015/06/unity-2d-scale-resize-camera-size-resolution.html
 *
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScalableCamera : MonoBehaviour
{
    public float targetWidth = 960.0f;
    public float targetHeight = 540.0f;
    public int pixelsPerUnit = 30; // 1:1 ratio of pixels to units

    void Start ()
    {
        float desiredRatio = targetWidth / targetHeight;
        float currentRatio = (float)Screen.width/(float)Screen.height;

        if(currentRatio >= desiredRatio) {
            // Our resolution has plenty of width, so we just need to use the height to determine the camera size
            Camera.main.orthographicSize = targetHeight / 4 / pixelsPerUnit;
        }
        else {
            // Our camera needs to zoom out further than just fitting in the height of the image.
            // Determine how much bigger it needs to be, then apply that to our original algorithm.
            float differenceInSize = desiredRatio / currentRatio;
            Camera.main.orthographicSize = targetHeight / 4 / pixelsPerUnit * differenceInSize;
        }
    }
}