using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPaddle : Paddle
{
    public override void Start()
    {
        base.Start();
        if (!PlayerPrefs.HasKey("aiSeeDistance"))
            PlayerPrefs.SetFloat("aiSeeDistance", GameManager.instance.defaultAiSeeDistance);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, GameManager.instance.ball.transform.transform.position);

        if (distance > PlayerPrefs.GetFloat("aiSeeDistance"))
            return;

        var y = 0;
        if (transform.position.y < GameManager.instance.ball.transform.position.y)
        {
            y = 1;
        }
        else if (transform.position.y > GameManager.instance.ball.transform.position.y)
        {
            y = -1;
        }

        UpdateMotor(y);
    }
}