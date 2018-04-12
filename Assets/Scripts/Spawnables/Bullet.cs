using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Spawnable
{
    public bool isEnemyBullet = false;

    private void Awake()
    {
        this.rigidbodyComponent = this.gameObject.GetComponent<Rigidbody2D>();
    }

    private void Start () {
        if (this.isEnemyBullet)
            this.direction *= -1;
	}

    private void FixedUpdate()
    {
        this.transform.Translate(this.direction * speed);
    }

    private void OnBecameInvisible()
    {
        GameObject.Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.isEnemyBullet)
        {
            Player playerComponent;
            if (playerComponent = collision.gameObject.GetComponent<Player>())
            {
                playerComponent.OnHitByBullet();
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
