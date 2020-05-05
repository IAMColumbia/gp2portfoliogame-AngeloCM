﻿using Assets.Scripts.Shot.TypesOfGuns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{    

    public Pistol(GunController gController)
    {
        gunController = gController;
        bulletSpeed = 15f;
        timeBetweenShots = 0.5f;
        amountOfBullets = 30;
        Damage = 5;
    }

    public override void Update()
    {
        if (gunController.isFiring)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                Shoot();
            }
        }
        else
        {
            shotCounter = 0;
        }
    }

    public override void Shoot()
    {
        if (amountOfBullets > 0)
        {
            BulletController newBullet = Instantiate(gunController.bullet, gunController.firePoint.position, gunController.firePoint.rotation) as BulletController;
            newBullet.speed = bulletSpeed;
            amountOfBullets--;

            newBullet.transform.parent = gunController.BulletsBeingShot.transform;
        }
        else
        {
            Debug.Log("Out of ammo!");
        }
        
    }
}
