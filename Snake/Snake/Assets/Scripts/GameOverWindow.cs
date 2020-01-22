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

        //transform.Find("scoreobtenu").GetComponent<Text>().text = "Vous avez eu " + Score.GetScore().ToString();

        string highscore = Score.GetHighScore().ToString();
        for (int i = 1; i < 5; i++)
        {
            highscore += "\n" + Score.GetHighScore(i).ToString();
        }

        transform.Find("scoreClassTxt").GetComponent<Text>().text = highscore;

        transform.Find("RetryButton").GetComponent<Button_UI>().ClickFunc = () => {
            Loader.Load(Loader.Scene.GameScene);
        };

        Hide();
    }

    private void Show()
    {
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
