using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public GameObject ball;
    public GameObject ballPrefab;

    public GameObject player1Paddle;
    public GameObject player2Paddle;

    public TextMeshProUGUI player2Txt;
    public TextMeshProUGUI player1Txt;

    public TextMeshProUGUI player1Wins;
    public TextMeshProUGUI player2Wins;

    public Canvas menuCanvas;

    public int winScore = 10;
    
    private int player2Score;
    private int player1Score;
    
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SetPlayers(false, false);
        ResetGame();
    }

    public void Score(bool didPlayer1Score)
    {
        if (didPlayer1Score)
        {
            player1Score++;
            player1Txt.text = player1Score.ToString();
        }
        else
        {
            player2Score++;
            player2Txt.text = player2Score.ToString();
        }

        if (player1Score == winScore || player2Score == winScore)
        {
            EndGame();
            if (didPlayer1Score)
            {
                player1Wins.enabled = true;
            }
            else
            {
                player2Wins.enabled = true;
            }
        }
        else
        {
            ResetBall();
        }
    }

    private void ResetGame()
    {
        player2Score = 0;
        player1Score = 0;
        player2Txt.text = player2Score.ToString();
        player1Txt.text = player1Score.ToString();
        player1Wins.enabled = false;
        player2Wins.enabled = false;
        ResetBall();
    }

    private void EndGame()
    {
        ResetGame();
        menuCanvas.enabled = true;
        SetPlayers(false, false);
    }
    

    private void ResetBall()
    {
        Destroy(ball);
        ball = Instantiate(ballPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    private void SetPlayers(bool player1Playing, bool player2Playing)
    {
        player1Paddle.GetComponent<PlayerPaddle>().enabled = player1Playing;
        player2Paddle.GetComponent<PlayerPaddle>().enabled = player2Playing;
        
        player1Paddle.GetComponent<ComputerPaddle>().enabled = !player1Playing;
        player2Paddle.GetComponent<ComputerPaddle>().enabled = !player2Playing;
    }

    public void Start1Player()
    {
        menuCanvas.enabled = false;
        ResetGame();
        SetPlayers(true, false);
    }
    public void Start2Player()
    {
        menuCanvas.enabled = false;
        ResetGame();
        SetPlayers(true, true);
    }
}
