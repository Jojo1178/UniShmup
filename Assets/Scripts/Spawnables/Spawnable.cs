using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawnable : MonoBehaviour {

    public float speed;
    public Vector2 direction;
    protected Rigidbody2D rigidbodyComponent;
}
