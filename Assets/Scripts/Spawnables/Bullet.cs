using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Spawnable
{
    public bool isEnemyBullet = false; // True if the bullet should harm the player, False if it should harm the enemies

    private void Awake()
    {
        this.rigidbodyComponent = this.gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (ApplicationController.Instance.applicationState == ApplicationState.GAME)
        {
            this.transform.Translate(this.direction * speed);
        }
    }

    //The bullet is out of the screen
    private void OnBecameInvisible()
    {
        GameObject.Destroy(this.gameObject);
    }

    //The bullet hit something
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.isEnemyBullet)
        {
            Player playerComponent;
            if (playerComponent = collision.gameObject.GetComponent<Player>())
            {
                playerComponent.OnHitByEnemy();
                GameObject.Destroy(this.gameObject);
            }
        }
        else
        {
            Enemy enemyComponent;
            if (enemyComponent = collision.gameObject.GetComponent<Enemy>())
            {
                enemyComponent.OnHitByBullet();
                GameObject.Destroy(this.gameObject);
            }
        }
    }
}
