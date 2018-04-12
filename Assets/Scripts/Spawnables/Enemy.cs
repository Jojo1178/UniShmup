using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Spawnable
{
    private BoxCollider2D boxCollider2D;
    private Weapon[] weapons; // Enemy available weapons
    private bool visible = false;

    private void Awake()
    {
        this.rigidbodyComponent = this.gameObject.GetComponent<Rigidbody2D>();
        this.weapons = this.gameObject.GetComponentsInChildren<Weapon>();
        this.boxCollider2D = this.gameObject.GetComponent<BoxCollider2D>();
        this.boxCollider2D.enabled = this.visible; //Waiting to be visible on screen to enable
        this.direction = new Vector2(0, -1);

    }

    private void Update()
    {
        if (this.visible && ApplicationController.INSTANCE.applicationState == ApplicationState.GAME)
        {
            foreach (Weapon weapon in this.weapons)
            {
                if (weapon.canShoot)
                {
                    weapon.Shoot();
                }
            }

        }
    }

    private void FixedUpdate()
    {
        if (ApplicationController.INSTANCE.applicationState == ApplicationState.GAME)
        {
            this.transform.Translate(this.direction * speed);
        }
    }

    private void OnBecameVisible()
    {
        // The ship reach the top of the screen
        this.visible = true;
        this.boxCollider2D.enabled = true;
    }

    private void OnBecameInvisible()
    {
        // The ship reach the bottom of the screen
        if (this.visible)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player;
        if(player = collision.gameObject.GetComponent<Player>()) // The ship bump into the player's ship
        {
            player.OnHitByEnemy();
            GameObject.Destroy(this.gameObject);
        }
    }

    public void OnHitByBullet()
    {
        ApplicationController.INSTANCE.mainGameController.AddToScore(100);
        ApplicationController.INSTANCE.mainGameController.TrySpawnPowerUp(this.transform.position);
        GameObject.Destroy(this.gameObject);
    }
}
