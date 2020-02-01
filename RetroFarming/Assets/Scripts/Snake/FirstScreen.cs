using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstScreen : MonoBehaviour
{
    private static FirstScreen instance;
    private static float timer;

    private void Awake()
    {
        instance = this;
        timer = 0.0f;

        Show();
    }

    private void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            timer += Time.deltaTime;
            if (timer >= 15f)
            {
                Application.Quit();
            }
        }
        else if (Input.GetButtonUp("Fire2"))
        {
            timer = 0.0f;
        }
    }

    private void Show()
    {
        //Play sound
        //SoundsManager.PlaySound(SoundsManager.Sound.gameOver);

        //Score Space Invader
        transform.Find("Score").Find("SpaceScoreText").GetComponent<Text>().text = "MEILLEUR SCORE :\n" + ScoreSI.GetHighScorePseudo(0) + " - " + ScoreSI.GetHighScore(0);
        //Score snake
        transform.Find("Score").Find("SnakeScoreText").GetComponent<Text>().text = "MEILLEUR SCORE :\n"+ Score.GetHighScorePseudo(0)+ " - " + Score.GetHighScore(0);

        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    public static void ShowStatic()
    {
        instance.Show();
    }
}
