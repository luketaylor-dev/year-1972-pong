using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    public float speed = 6f;
    public int hitsTillSpeed = 10;
    public float speedIncrease = 1.1f;
    private Rigidbody2D rb;
    private Vector2 lastVelocity;
    private int hits = 0;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Start()
    {
        Launch();
        lastVelocity = rb.velocity;
    }

    private void Launch()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(speed * x, speed * y);
    }

    public void Update()
    {
        if (lastVelocity.x < 0 && rb.velocity.x > 0 || lastVelocity.x > 0 && rb.velocity.x < 0)
        {
            hits++;
            if(hits > hitsTillSpeed)
                rb.velocity *= speedIncrease;
        }

        lastVelocity = rb.velocity;
    }
}