using UnityEngine;

public abstract class Spawnable : MonoBehaviour {
    //Common variables between enemies, bullets and player
    public float speed;
    public Vector2 direction;
    protected Rigidbody2D rigidbodyComponent;
}
