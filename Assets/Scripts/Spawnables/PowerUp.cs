using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : Spawnable {

    private void Awake()
    {
        this.rigidbodyComponent = this.gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player;
        if (player = collision.gameObject.GetComponent<Player>())   // The player hit the power-up
        {
            player.OnHitPowerUp();
            GameObject.Destroy(this.gameObject);
        }
    }
}
