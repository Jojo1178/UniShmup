using UnityEngine;
using UnityEngine.EventSystems;

public class Player : Spawnable
{
    private Weapon[] weapons; //Player's available weapons
    private Camera mainCamera;

    private void Awake()
    {
        this.rigidbodyComponent = this.gameObject.GetComponent<Rigidbody2D>();
        this.weapons = this.gameObject.GetComponentsInChildren<Weapon>(true);
        this.mainCamera = Camera.main;
    }

    private void Update()
    {
        if (ApplicationController.Instance.applicationState == ApplicationState.GAME)
        {
            // Checking if mouse isn't over an UI element and if fire button is pressed
            bool shootInput = !EventSystem.current.IsPointerOverGameObject() && (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"));
            if (shootInput)
            {
                foreach (Weapon weapon in this.weapons)
                {
                    if (weapon.enabled && weapon.canShoot)
                    {
                        weapon.Shoot();
                    }
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (ApplicationController.Instance.applicationState == ApplicationState.GAME)
        {
            //Get direction input
            float inputX = Input.GetAxis("Horizontal");
            float inputY = Input.GetAxis("Vertical");

            this.direction = new Vector2(inputX, inputY);
            this.transform.Translate(this.direction * speed);

            // Clamp to screen
            Vector3 currentScreenPosition = this.mainCamera.WorldToScreenPoint(this.transform.position);
            currentScreenPosition.x = Mathf.Clamp(currentScreenPosition.x, 50, Screen.width-50);
            currentScreenPosition.y = Mathf.Clamp(currentScreenPosition.y, 50, Screen.height-50);
            this.transform.position = this.mainCamera.ScreenToWorldPoint(currentScreenPosition);
        }
    }

    //When player's ship is hit by a bullet or an enemy ship
    public void OnHitByEnemy()
    {
        GameObject.Destroy(this.gameObject);
        ApplicationController.Instance.ChangeApplicationState(ApplicationState.GAMEOVER);
    }

    //When player get a power-up
    public void OnHitPowerUp()
    {
        foreach(Weapon weapon in this.weapons)
        {
            if (!weapon.enabled)
            {
                weapon.enabled = true;
                break;
            }
        }
    }
}
