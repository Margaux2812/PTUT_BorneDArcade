using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using UnityEngine.UI;

public class GameOverWindow : MonoBehaviour
{
    public InputField pseudo;
    private static GameOverWindow instance;

    public void setgetinput()
    {
        if(pseudo.text == "")
        {
            Score.setPseudo("Utilisateur");
        }
        else {
            Score.setPseudo(pseudo.text);
        }
       
    }

    private void Awake()
    {
        instance = this;

        transform.Find("RetryButton").GetComponent<Button_UI>().ClickFunc = () => {
            Loader.Load(Loader.Scene.GameScene);
        };

        transform.Find("Retour").GetComponent<Button_UI>().ClickFunc = () => {
            Loader.Load(Loader.Scene.MenuSceneSnake);
        };

        Hide();
    }

    private void Show()
    {
        //Play sound
        SoundsManager.PlaySound(SoundsManager.Sound.gameOver);

        //Load le score actuel
        transform.Find("scoreobtenu").GetComponent<Text>().text = "VOUS AVEZ EU " + GameHandler.GetScore().ToString();
        //Donner le score
        Score.setScore(GameHandler.GetScore());
        //Update le tableau
        Score.updateHighscore();

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

    private void ShowUpdated()
    {
        //Load le score actuel
        transform.Find("scoreobtenu").GetComponent<Text>().text = "VOUS AVEZ EU " + GameHandler.GetScore().ToString();
        
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
    }

    private void Hide()
    {
        Score.setPseudo("Inconnu");
        gameObject.SetActive(false);
    }

    public static void ShowStatic()
    {
        instance.Show();
    }

    public static void ShowStaticUpdated()
    {
        instance.ShowUpdated();
    }
}
