using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool isPlayer1Goal;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Ball")) return;
        if (!isPlayer1Goal)
        {
            Debug.Log("Player 1 Scored...");
            GameManager.instance.Score(true);
        }
        else
        {
            Debug.Log("Player 2 Scored...");
            GameManager.instance.Score(false);
        }
    }
}