using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    //ball speed settings
    public float speed = 6f;
    public int hitsTillSpeed = 10;
    public float speedIncrease = 1.1f;
    
    public Rigidbody2D rb;
    private int hits = 0;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Start()
    {
        Launch();
    }

    private void Launch()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(speed * x, speed * y);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            hits++;
            if(hits > hitsTillSpeed)
                rb.velocity *= speedIncrease;
            GameManager.instance.paddleSound.Play();

        }
        else
        {
            GameManager.instance.wallSound.Play();
        }
        
}
}