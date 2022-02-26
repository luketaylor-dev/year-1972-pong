using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    protected Vector3 moveDelta;
    public float yspeed = 6f;
    private Rigidbody2D rb;
    public bool isPlayer1;
    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void UpdateMotor(float input)
    {
        rb.velocity = new Vector2(rb.velocity.x, input * yspeed);
    }
}