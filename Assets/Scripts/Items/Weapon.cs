using System.Collections;
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
    public float shootTimer = 0.5f;

    private float shootCooldown;


    private void Start () {
        this.shootCooldown = 0f;

    }
	
	private void Update () {
        if (this.shootCooldown > 0)
        {
            this.shootCooldown -= Time.deltaTime;
        }
    }

    public void Shoot(bool isEnemy)
    {
        if (this.canShoot)
        {
            this.shootCooldown = this.shootTimer;

            //Bullet instanciation
            Bullet bullet = GameObject.Instantiate(this.bulletPrefab) as Bullet;
            bullet.isEnemyBullet = isEnemy;
            bullet.transform.position = this.transform.position;
            bullet.direction = this.transform.up;
            bullet.transform.SetParent(ApplicationController.INSTANCE.mainGameController.gameSceneRoot, false);

        }
    }
}
