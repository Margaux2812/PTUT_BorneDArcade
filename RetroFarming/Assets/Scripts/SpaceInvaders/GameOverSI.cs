using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using UnityEngine.UI;

public class GameOverSI : MonoBehaviour
{
    public InputField pseudo;
    private static GameOverSI instance;
    private Game game;

    public void SetGetInput()
    {
        if (pseudo.text == "")
        {
            ScoreSI.SetPseudo("Utilisateur");
        }
        else
        {
            ScoreSI.SetPseudo(pseudo.text);
        }
    }

    private void Awake()
    {
        instance = this;
        
        game = GameObject.Find("EventSystem").GetComponent<Game>();

        Hide();
    }

    private void Show()
    {
        float score = game.ScoreGame;

        //Load current score
        transform.Find("TxtScoreObtained").GetComponent<Text>().text = "VOUS AVEZ EU " + (int)score + " POINTS";

        //Give score
        ScoreSI.SetScore(game.ScoreGame);
        
        //Update table
        ScoreSI.UpdateHighscore();

        //Load highscore
        string highscore = ScoreSI.GetHighScore().ToString();
        for (int i = 1; i < 5; i++)
        {
            highscore += "\n" + ScoreSI.GetHighScore(i).ToString();
        }

        transform.Find("TxtScore").GetComponent<Text>().text = highscore;
        string highscorePseudo = ScoreSI.GetHighScorePseudo().ToString();
        for (int i = 1; i < 5; i++)
        {
            highscorePseudo += "\n" + ScoreSI.GetHighScorePseudo(i).ToString();
        }

        transform.Find("TxtPseudo").GetComponent<Text>().text = highscorePseudo;

        gameObject.SetActive(true);
    }

    private void ShowUpdated()
    {
        //Load current score
        transform.Find("TxtScoreObtained").GetComponent<Text>().text = "VOUS AVEZ EU " + game.ScoreGame;

        //Load highscore
        string highscore = ScoreSI.GetHighScore().ToString();
        for (int i = 1; i < 5; i++)
        {
            highscore += "\n" + ScoreSI.GetHighScore(i).ToString();
        }

        transform.Find("TxtScore").GetComponent<Text>().text = highscore;

        string highscorePseudo = ScoreSI.GetHighScorePseudo().ToString();
        for (int i = 1; i < 5; i++)
        {
            highscorePseudo += "\n" + ScoreSI.GetHighScorePseudo(i).ToString();
        }

        transform.Find("TxtPseudo").GetComponent<Text>().text = highscorePseudo;
    }

    private void Hide()
    {
        ScoreSI.SetPseudo("Inconnu");
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