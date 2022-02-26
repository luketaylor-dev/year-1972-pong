using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddle : Paddle
{
    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isPaused)
        {
            UpdateMotor(0);
            return;
        }
        UpdateMotor(Input.GetAxisRaw(isPlayer1 ? "Vertical" : "Vertical2"));
    }
}
