using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterParentController : Shooter
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (Shooter shooter in GetComponentsInChildren<Shooter>()) {
            shooter.attackRate = attackRate;
            shooter.angleOffset = angleOffset;
            shooter.speed = speed;
            shooter.damage = damage;
            shooter.delay = delay;
            shooter.homing = homing;
            shooter.rotationSpeed = rotationSpeed;
            shooter.laser = laser;
            shooter.homingLaser = homingLaser;
            shooter.laserFireTime = laserFireTime;
            shooter.laserOffTime = laserOffTime;
            shooter.Start();
        }
        this.enabled = false;
    }

    void Update() {
    }
}
