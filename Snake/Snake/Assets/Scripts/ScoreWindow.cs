using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreWindow : MonoBehaviour
{
    private Text score;

    private void Awake()
    {
        score = transform.Find("Score").GetComponent<Text>();

        //Score.reInitialize();
        string highscore = Score.GetHighScore().ToString();
        transform.Find("highscoreText").GetComponent<Text>().text = "HIGHSCORE : " + highscore;
    }

    private void Update()
    {
        score.text = "SCORE : " + GameHandler.GetScore().ToString();
    }
    
}
