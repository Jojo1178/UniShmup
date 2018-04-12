using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawnable : MonoBehaviour {
    //Common variables between ennemy, bullet and player
    public float speed;
    public Vector2 direction;
    protected Rigidbody2D rigidbodyComponent;
}
