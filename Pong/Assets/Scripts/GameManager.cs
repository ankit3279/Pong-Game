using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject ball;

    private int playerScore = 0;

    private int aiScore = 0;

    public TextMeshProUGUI playerScoreText;

    public TextMeshProUGUI aiScoreText;

    private void Awake()
    {
        instance = this;
    }

    public void Scored(Scorer scorer)
    {
        switch (scorer)
        {
            case Scorer.Player:
                playerScore++;
                break;
            case Scorer.AI:
                aiScore++;
                break;
        }

        ball.GetComponent<BallScript>().ResetBall();
    }

    private void OnGUI()
    {
        aiScoreText.text = aiScore.ToString();
        playerScoreText.text = playerScore.ToString();
    }

}

public enum Scorer { 
    AI,
    Player,
}