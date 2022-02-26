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

    protected virtual void UpdateMotor(Vector3 input)
    {
        
        //Reset MoveDelta
        moveDelta = new Vector3(0, input.y * yspeed, 0);
        

        // Make player move
        transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
    }
}