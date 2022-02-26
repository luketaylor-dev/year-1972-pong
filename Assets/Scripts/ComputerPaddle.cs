using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPaddle : Paddle
{

    // Update is called once per frame
    void Update()
    {
        int y = 0;
        if (transform.position.y < GameManager.instance.ball.transform.position.y)
        {
            y = 1;
        }
        else if (transform.position.y > GameManager.instance.ball.transform.position.y)
        {
            y = -1;
        }
        if (y == -1 && transform.position.y <= -3.5 || y == 1 && transform.position.y >= 3.5)
        {
            return;
        }
        UpdateMotor(new Vector3(0, y, 0));
    }
}
