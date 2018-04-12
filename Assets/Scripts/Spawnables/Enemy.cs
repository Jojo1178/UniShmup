using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Spawnable
{
    private BoxCollider2D boxCollider2D;
    private Weapon[] weapons;
    private bool visible = false;

    private void Awake()
    {
        this.rigidbodyComponent = this.gameObject.GetComponent<Rigidbody2D>();
        this.weapons = this.gameObject.GetComponentsInChildren<Weapon>();
        this.boxCollider2D = this.gameObject.GetComponent<BoxCollider2D>();
        this.boxCollider2D.enabled = this.visible;
        this.direction = new Vector2(0, -1);

        //Randomize enemy fire rate
        float randomWeaponTimer = UnityEngine.Random.Range(1.5f,2);
        foreach(Weapon weapon in this.weapons)
        {
            weapon.shootTimer = randomWeaponTimer;
        }

    }

    private void Update()
    {
        if (this.visible)
        {
            foreach (Weapon weapon in this.weapons)
            {
                if (weapon.canShoot)
                {
                    weapon.Shoot(true);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        this.transform.Translate(this.direction * speed);
    }

    private void OnBecameVisible()
    {
        this.visible = true;
        this.boxCollider2D.enabled = true;
    }

    private void OnBecameInvisible()
    {
        if (this.visible)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    public void OnHitByBullet()
    {
        ApplicationController.INSTANCE.mainGameController.AddToScore(100);
        GameObject.Destroy(this.gameObject);
    }
}
