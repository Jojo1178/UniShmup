using UnityEngine;

public class PowerUp : Spawnable {

    public float powerUpLifeTimeSec = 5; //Life time of the power-up in sec

    private float timer;

    private void Awake()
    {
        this.rigidbodyComponent = this.gameObject.GetComponent<Rigidbody2D>();
        this.timer = 0;
    }

    private void Update()
    {
        this.timer += Time.deltaTime;
        if(this.timer > this.powerUpLifeTimeSec)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player;
        if (player = collision.gameObject.GetComponent<Player>())   // The player grabs the power-up
        {
            player.OnHitPowerUp();
            GameObject.Destroy(this.gameObject);
        }
    }
}
