using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddle : Paddle
{
    // Update is called once per frame
    void Update()
    {
        UpdateMotor(new Vector3(0, Input.GetAxisRaw(isPlayer1 ? "Vertical" : "Vertical2"), 0));
    }
}
