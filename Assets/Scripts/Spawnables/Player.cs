using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Spawnable
{
    private Weapon[] weapons;

    private void Awake()
    {
        this.rigidbodyComponent = this.gameObject.GetComponent<Rigidbody2D>();
        this.weapons = this.gameObject.GetComponentsInChildren<Weapon>();
    }

    private void Update()
    {
        bool shootInput = Input.GetButtonDown("Fire1") | Input.GetButtonDown("Fire2");
        if (shootInput)
        {
            foreach (Weapon weapon in this.weapons)
            {
                if (weapon.canShoot)
                {
                    weapon.Shoot(false);
                }
            }
        }
    }

    private void FixedUpdate()
    {

        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        this.direction = new Vector2(inputX,inputY);

        this.transform.Translate(this.direction * speed);

        // Clamp to screen
        Camera mainCamera = Camera.main;
        Vector3 currentScreenPosition = mainCamera.WorldToScreenPoint(this.transform.position);
        currentScreenPosition.x = Mathf.Clamp(currentScreenPosition.x, 0, Screen.width);
        currentScreenPosition.y = Mathf.Clamp(currentScreenPosition.y, 0, Screen.height);
        this.transform.position = mainCamera.ScreenToWorldPoint(currentScreenPosition);
    }

    private void OnDestroy()
    {
        ApplicationController.INSTANCE.SwitchApplicationState(ApplicationState.GAMEOVER);
    }

    public void OnHitByBullet()
    {
        GameObject.Destroy(this.gameObject);
    }
}
