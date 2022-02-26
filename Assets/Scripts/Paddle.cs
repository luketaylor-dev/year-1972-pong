using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //settings
    public float yspeed = 6f;
    public bool isPlayer1;
    
    private Rigidbody2D rb;
    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void UpdateMotor(float input)
    {
        rb.velocity = new Vector2(rb.velocity.x, input * yspeed);
    }
}