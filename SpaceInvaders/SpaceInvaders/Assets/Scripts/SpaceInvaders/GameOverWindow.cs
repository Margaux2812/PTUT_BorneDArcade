using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using UnityEngine.UI;

public class GameOverWindow : MonoBehaviour
{
    private Game game;
    public InputField pseudo;
    private static GameOverWindow instance;

    public void setgetinput()
    {
        if(pseudo.text == "")
        {
            ScoreSpaceInvaders.setPseudo("Utilisateur");
        }
        else {
            ScoreSpaceInvaders.setPseudo(pseudo.text);
        }
       
    }

    private void Awake()
    {
        game = GameObject.Find("EventSystem").GetComponent<Game>();

        instance = this;

        transform.Find("RetryButton").GetComponent<Button_UI>().ClickFunc = () => {
            Loader.Load(Loader.Scene.GameScene_SpaceInvaders);
        };

        transform.Find("ReturnButton").GetComponent<Button_UI>().ClickFunc = () => {
            Loader.Load(Loader.Scene.MenuScene_SpaceInvaders);
        };

        /*transform.Find("Button").GetComponent<Button_UI>().ClickFunc = () =>
        {
            Loader.Load(Loader.Scene.GameScene_SpaceInvaders);
        };*/

        Hide();
    }

    private void Show()
    {
        //Play sound
        //SoundsManager.PlaySound(SoundsManager.Sound.gameOver);

        //Load le score actuel
        transform.Find("TxtScoreObtained").GetComponent<Text>().text = "VOUS AVEZ EU " + game.ScoreGame;
        //Donner le score
        ScoreSpaceInvaders.setScore(game.ScoreGame);
        //Update le tableau
        ScoreSpaceInvaders.updateHighscore();

        //Load le highscore
        string highscore = ScoreSpaceInvaders.GetHighScore().ToString();
        for (int i = 1; i < 5; i++)
        {
            highscore += "\n" + ScoreSpaceInvaders.GetHighScore(i).ToString();
        }

        transform.Find("TxtScore").GetComponent<Text>().text = highscore;

        string highscorePseudo = ScoreSpaceInvaders.GetHighScorePseudo().ToString();
        for (int i = 1; i < 5; i++)
        {
            highscorePseudo += "\n" + ScoreSpaceInvaders.GetHighScorePseudo(i).ToString();
        }

        transform.Find("TxtPseudo").GetComponent<Text>().text = highscorePseudo;

        gameObject.SetActive(true);
    }

    private void ShowUpdated()
    {
        //Load le score actuel
        transform.Find("TxtScoreObtained").GetComponent<Text>().text = "VOUS AVEZ EU " + game.ScoreGame;
        
        //Load le highscore
        string highscore = ScoreSpaceInvaders.GetHighScore().ToString();
        for (int i = 1; i < 5; i++)
        {
            highscore += "\n" + ScoreSpaceInvaders.GetHighScore(i).ToString();
        }

        transform.Find("TxtScore").GetComponent<Text>().text = highscore;

        string highscorePseudo = ScoreSpaceInvaders.GetHighScorePseudo().ToString();
        for (int i = 1; i < 5; i++)
        {
            highscorePseudo += "\n" + ScoreSpaceInvaders.GetHighScorePseudo(i).ToString();
        }

        transform.Find("TxtPseudo").GetComponent<Text>().text = highscorePseudo;
    }

    private void Hide()
    {
        ScoreSpaceInvaders.setPseudo("Inconnu");
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
