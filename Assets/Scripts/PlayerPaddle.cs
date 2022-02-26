using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddle : Paddle
{
    private float y;

    // Update is called once per frame
    void Update()
    {
        if (isPlayer1)
        {
            y = Input.GetAxisRaw("Vertical");
        }
        else
        {
            y = Input.GetAxisRaw("Vertical2");
        }
        UpdateMotor(new Vector3(0, y, 0));
    }
}
