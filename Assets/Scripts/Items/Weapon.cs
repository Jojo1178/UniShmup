﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public bool canShoot
    {
        get
        {
            return this.shootCooldown <= 0f;
        }
    }

    public Bullet bulletPrefab;
    public float shotDelay = 0.5f; // Delay between each shot

    private float shootCooldown; // Time since last shot


    private void Start () {
        this.shootCooldown = 0f;
    }
	
	private void Update () {
        if (ApplicationController.Instance.applicationState == ApplicationState.GAME)
        {
            if (this.shootCooldown > 0)
            {
                this.shootCooldown -= Time.deltaTime;
            }
        }
    }

    public void Shoot()
    {
        if (this.canShoot)
        {
            this.shootCooldown = this.shotDelay;

            //Bullet instantiation
            Bullet bullet = GameObject.Instantiate(this.bulletPrefab) as Bullet;
            bullet.transform.position = this.transform.position;
            bullet.direction = this.transform.up;
            if (bullet.isEnemyBullet)
                bullet.direction *= -1; // enemy shoot towards the bottom of the screen
            bullet.transform.SetParent(ApplicationController.Instance.mainGameController.gameSceneRoot, false);

        }
    }
}
