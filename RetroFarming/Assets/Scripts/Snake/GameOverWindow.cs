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

        Hide();
    }

    private void Show()
    {
        //Play sound
        SoundsManager.PlaySound(SoundsManager.Sound.gameOver);

        float score = GameHandler.GetScore() + ((float)GameHandler.GetScore() / GameHandler.GetTime());

        //Load le score actuel
        transform.Find("TxtScoreObtained").GetComponent<Text>().text = "VOUS AVEZ EU " + (int)score + " POINTS";
        //Donner le score
        Score.setScore((int)(GameHandler.GetScore() + ((float)GameHandler.GetScore() / GameHandler.GetTime())));
        //Update le tableau
        Score.updateHighscore();

        //Load le highscore
        string highscore = Score.GetHighScore().ToString();
        for (int i = 1; i < 5; i++)
        {
            highscore += "\n" + Score.GetHighScore(i).ToString();
        }

        transform.Find("TxtScore").GetComponent<Text>().text = highscore;

        string highscorePseudo = Score.GetHighScorePseudo().ToString();
        for (int i = 1; i < 5; i++)
        {
            highscorePseudo += "\n" + Score.GetHighScorePseudo(i).ToString();
        }

        transform.Find("TxtPseudo").GetComponent<Text>().text = highscorePseudo;

        gameObject.SetActive(true);
    }

    private void ShowUpdated()
    {
        //Load le score actuel
        transform.Find("TxtScoreObtained").GetComponent<Text>().text = "VOUS AVEZ EU " + GameHandler.GetScore().ToString();
        
        //Load le highscore
        string highscore = Score.GetHighScore().ToString();
        for (int i = 1; i < 5; i++)
        {
            highscore += "\n" + Score.GetHighScore(i).ToString();
        }

        transform.Find("TxtScore").GetComponent<Text>().text = highscore;

        string highscorePseudo = Score.GetHighScorePseudo().ToString();
        for (int i = 1; i < 5; i++)
        {
            highscorePseudo += "\n" + Score.GetHighScorePseudo(i).ToString();
        }

        transform.Find("TxtPseudo").GetComponent<Text>().text = highscorePseudo;
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
