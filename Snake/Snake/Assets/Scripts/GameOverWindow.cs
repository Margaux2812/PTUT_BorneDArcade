using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using UnityEngine.UI;

public class GameOverWindow : MonoBehaviour
{
    private static GameOverWindow instance;

    private void Awake()
    {
        instance = this;

        transform.Find("RetryButton").GetComponent<Button_UI>().ClickFunc = () => {
            Loader.Load(Loader.Scene.GameScene);
        };

        Hide();
    }

    private void Show()
    {
        //Play sound
        SoundsManager.PlaySound(SoundsManager.Sound.gameOver);

        //Load le score actuel
        transform.Find("scoreobtenu").GetComponent<Text>().text = "Vous avez eu " + GameHandler.GetScore().ToString();

        //Load le highscore
        string highscore = Score.GetHighScore().ToString();
        for (int i = 1; i < 5; i++)
        {
            highscore += "\n" + Score.GetHighScore(i).ToString();
        }

        transform.Find("scoreClassTxt").GetComponent<Text>().text = highscore;

        string highscorePseudo = Score.GetHighScorePseudo().ToString();
        for (int i = 1; i < 5; i++)
        {
            highscorePseudo += "\n" + Score.GetHighScorePseudo(i).ToString();
        }

        transform.Find("pseudoClassTxt").GetComponent<Text>().text = highscorePseudo;

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
