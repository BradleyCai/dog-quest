﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicRotator : MonoBehaviour
{
    public float angularSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, angularSpeed);
    }
}
