using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreWindow : MonoBehaviour
{
    private Text score;
    private Text timer;

    private void Awake()
    {
        score = transform.Find("Score").GetComponent<Text>();
        timer = transform.Find("Timer").GetComponent<Text>();

        //Score.reInitialize();
        string highscore = Score.GetHighScore().ToString();
        transform.Find("highscoreText").GetComponent<Text>().text = "MEILLEUR SCORE < " + highscore + " >";
    }

    private void Update()
    {
        score.text = "SCORE < " + GameHandler.GetScore().ToString() + " >";
        timer.text = "TEMPS " + ((int)GameHandler.GetTime()).ToString();
    }
    
}
