using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using UnityEngine.UI;

public class GameOverSI : MonoBehaviour
{
    private Game game;
    public InputField pseudo;
    private static GameOverSI instance;

    public void SetGetInput()
    {
        if(pseudo.text == "")
        {
            ScoreSI.SetPseudo("Utilisateur");
        }
        else {
            ScoreSI.SetPseudo(pseudo.text);
        }
       
    }

    private void Awake()
    {
        game = GameObject.Find("EventSystem").GetComponent<Game>();
        instance = this;
        transform.Find("ButtonRetry").GetComponent<Button_UI>().ClickFunc = () => {
            Loader.Load(Loader.Scene.GameScene_SpaceInvaders);
        };
        transform.Find("ButtonReturn").GetComponent<Button_UI>().ClickFunc = () => {
            Loader.Load(Loader.Scene.MenuScene_SpaceInvaders);
        };
        Hide();
    }

    private void Show()
    {
        //Load current score
        transform.Find("TxtScoreObtained").GetComponent<Text>().text = "VOUS AVEZ EU " + game.ScoreGame;
        
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
