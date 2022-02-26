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
    
    //assets
    public GameObject ball;
    public GameObject ballPrefab;
    public GameObject player1Paddle;
    public GameObject player2Paddle;
    
    //audio
    public AudioSource paddleSound;
    public AudioSource wallSound;
    public AudioSource scoreSound;
    
    //ui
    public TextMeshProUGUI player2Txt;
    public TextMeshProUGUI player1Txt;
    public TextMeshProUGUI player1Wins;
    public TextMeshProUGUI player2Wins;
    public Canvas menuCanvas;
    public Canvas pauseCanvas;

    //settings
    public int winScore = 10;
    public float defaultAiSeeDistance =  7f;
    public bool isBotGame = true;
    public bool isPaused = false;
    
    private int player2Score;
    private int player1Score;

    private Vector2 ballVelocityPrePuase;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SetPlayers(false, false);
        isBotGame = true;
        ResetGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    private void PauseGame()
    {
        ballVelocityPrePuase = ball.GetComponent<Ball>().rb.velocity;
        ball.GetComponent<Ball>().rb.velocity = Vector2.zero;
        pauseCanvas.enabled = true;
        isPaused = true;
    }

    public void Resume()
    {
        ball.GetComponent<Ball>().rb.velocity = ballVelocityPrePuase;
        pauseCanvas.enabled = false;
        isPaused = false;
    }

    public void QuitToMenu()
    {
        EndGame();
    }

    public void Score(bool didPlayer1Score)
    {
        scoreSound.Play();
        if (didPlayer1Score)
        {
            player1Score++;
            player1Txt.text = player1Score.ToString();
            
            //if player2 is a computer and player 1 is a player, increase computers see distance
            if (player2Paddle.GetComponent<ComputerPaddle>().enabled && !isBotGame)
            {
                PlayerPrefs.SetFloat("aiSeeDistance", PlayerPrefs.GetFloat("aiSeeDistance") + 0.5f);
            }
        }
        else
        {
            player2Score++;
            player2Txt.text = player2Score.ToString();
            //if player2 is a computer and player 1 is a player, decrease computers see distance
            if (player2Paddle.GetComponent<ComputerPaddle>().enabled && !isBotGame)
            {
                PlayerPrefs.SetFloat("aiSeeDistance", PlayerPrefs.GetFloat("aiSeeDistance") - 0.5f);
            }
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
        pauseCanvas.enabled = false;
        isPaused = false;
        ResetBall();
    }

    private void EndGame()
    {
        ResetGame();
        menuCanvas.enabled = true;
        SetPlayers(false, false);
        isBotGame = true;
    }
    

    private void ResetBall()
    {
        Destroy(ball);
        ball = Instantiate(ballPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    //set players/computers depending what picked
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
        isBotGame = false;
    }
    public void Start2Player()
    {
        menuCanvas.enabled = false;
        ResetGame();
        SetPlayers(true, true);
        isBotGame = false;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
