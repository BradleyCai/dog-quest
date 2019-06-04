using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterParentController : Shooter
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (Shooter shooter in GetComponentsInChildren<Shooter>()) {
            shooter.bulletPrefab = bulletPrefab;
            shooter.speed = speed;
            shooter.damage = damage;
            shooter.delay = delay;
            shooter.attackRate = attackRate;
            shooter.homingBullet = homingBullet;
            shooter.rotationSpeed = rotationSpeed;
            shooter.randomAngle = randomAngle;
            shooter.startAngle = startAngle;
            shooter.stopAngle = stopAngle;
            shooter.laser = laser;
            shooter.laserFireTime = laserFireTime;
            shooter.laserOffTime = laserOffTime;
            shooter.homingLaser = homingLaser;
            shooter.laserHomingFireTime = laserHomingFireTime;
            shooter.laserHomingOffTime = laserHomingOffTime;
            shooter.Start();
        }
        this.enabled = false;
    }

    void Update() {
    }
}
