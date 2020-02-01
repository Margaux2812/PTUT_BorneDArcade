using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Score
{

   public static int GetHighScore(int index = 0)
    {
        switch (index)
        {
            case 0:
                return PlayerPrefs.GetInt("highscore", 0);
            case 1:
                return PlayerPrefs.GetInt("highscore2", 0);
            case 2:
                return PlayerPrefs.GetInt("highscore3", 0);
            case 3:
                return PlayerPrefs.GetInt("highscore4", 0);
            case 4:
                return PlayerPrefs.GetInt("highscore5", 0);
            case 5:
                return PlayerPrefs.GetInt("highscore6", 0);
            case 6:
                return PlayerPrefs.GetInt("highscore7", 0);
            case 7:
                return PlayerPrefs.GetInt("highscore8", 0);
            case 8:
                return PlayerPrefs.GetInt("highscore9", 0);
            case 9:
                return PlayerPrefs.GetInt("highscore10", 0);
            default: return PlayerPrefs.GetInt("highscore", 0);
        }
    }

    public static string GetHighScorePseudo(int index = 0)
    {
        switch (index)
        {
            case 0:
                return PlayerPrefs.GetString("highscorePseudo", "Utilisateur inconnu");
            case 1:
                return PlayerPrefs.GetString("highscore2Pseudo", "Utilisateur inconnu");
            case 2:
                return PlayerPrefs.GetString("highscore3Pseudo", "Utilisateur inconnu");
            case 3:
                return PlayerPrefs.GetString("highscore4Pseudo", "Utilisateur inconnu");
            case 4:
                return PlayerPrefs.GetString("highscore5Pseudo", "Utilisateur inconnu");
            case 5:
                return PlayerPrefs.GetString("highscore6Pseudo", "Utilisateur inconnu");
            case 6:
                return PlayerPrefs.GetString("highscore7Pseudo", "Utilisateur inconnu");
            case 7:
                return PlayerPrefs.GetString("highscore8Pseudo", "Utilisateur inconnu");
            case 8:
                return PlayerPrefs.GetString("highscore9Pseudo", "Utilisateur inconnu");
            case 9:
                return PlayerPrefs.GetString("highscore10Pseudo", "Utilisateur inconnu");
            default: return PlayerPrefs.GetString("highscorePseudo", "Utilisateur inconnu");
        }
    }

    public static int GetScore()
    {
        return PlayerPrefs.GetInt("actualScore", 0);
    }

    public static void SetHighScore(string pseudo, int index, int score)
    {
        switch (index)
        {
            case 0:
                PlayerPrefs.SetInt("highscore", score);
                PlayerPrefs.SetString("highscorePseudo", pseudo);
                break;
            case 1:
                PlayerPrefs.SetInt("highscore2", score);
                PlayerPrefs.SetString("highscore2Pseudo", pseudo);
                break;
            case 2:
                PlayerPrefs.SetInt("highscore3", score);
                PlayerPrefs.SetString("highscore3Pseudo", pseudo);
                break;
            case 3:
                PlayerPrefs.SetInt("highscore4", score);
                PlayerPrefs.SetString("highscore4Pseudo", pseudo);
                break;
            case 4:
                PlayerPrefs.SetInt("highscore5", score);
                PlayerPrefs.SetString("highscore5Pseudo", pseudo);
                break;
            case 5:
                PlayerPrefs.SetInt("highscore6", score);
                PlayerPrefs.SetString("highscore6Pseudo", pseudo);
                break;
            case 6:
                PlayerPrefs.SetInt("highscore7", score);
                PlayerPrefs.SetString("highscore7Pseudo", pseudo);
                break;
            case 7:
                PlayerPrefs.SetInt("highscore8", score);
                PlayerPrefs.SetString("highscore8Pseudo", pseudo);
                break;
            case 8:
                PlayerPrefs.SetInt("highscore9", score);
                PlayerPrefs.SetString("highscore9Pseudo", pseudo);
                break;
            case 9:
                PlayerPrefs.SetInt("highscore10", score);
                PlayerPrefs.SetString("highscore10Pseudo", pseudo);
                break;
            default: break;
        }
        PlayerPrefs.Save();
    }

    public static void updateHighscore()
    {
        int score = PlayerPrefs.GetInt("score", 0);

        int indexToSwitch = -1;
        for (int i = 0; i < 10; i++)
        {
            int highscore = GetHighScore(i);
            if (score > highscore)
            {
                indexToSwitch = i;
                break;
            }
        }

        if (indexToSwitch != -1)
        {
            swap(indexToSwitch, score, PlayerPrefs.GetString("pseudo", "VOUS"));
        }

        PlayerPrefs.Save();
    }

    private static void changeVous(string pseudo)
    {
        for(int i=0; i<10; i++)
        {
            if(GetHighScorePseudo(i) == "VOUS")
            {
                SetHighScore(pseudo, i, GetHighScore(i));
            }
        }
        GameOverWindow.ShowStaticUpdated();
    }

    public static void setPseudo(string pseudo)
    {
        PlayerPrefs.SetString("pseudo", pseudo);
        changeVous(pseudo);
        PlayerPrefs.Save();
    }

    public static void setScore(int score)
    {
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.SetString("pseudo", "VOUS");
        PlayerPrefs.Save();
    }

    public static void swap(int index, int newscore, string pseudo)
    {
        int lastScore = GetHighScore(index);
        string lastPseudo = GetHighScorePseudo(index);
        SetHighScore(pseudo, index, newscore);
        int tmp;
        string tmpPseudo;

        for (int i=index+1; i<10; i++)
        {
            tmp = GetHighScore(i);
            tmpPseudo = GetHighScorePseudo(i);
            SetHighScore(lastPseudo, i, lastScore);
            lastScore = tmp;
            lastPseudo = tmpPseudo;
        }
    }

    public static void reInitialize()
    {
        PlayerPrefs.SetInt("highscore" , 0);
        PlayerPrefs.SetInt("highscore2", 0);
        PlayerPrefs.SetInt("highscore3", 0);
        PlayerPrefs.SetInt("highscore4", 0);
        PlayerPrefs.SetInt("highscore5", 0);
        PlayerPrefs.SetInt("highscore6", 0);
        PlayerPrefs.SetInt("highscore7", 0);
        PlayerPrefs.SetInt("highscore8", 0);
        PlayerPrefs.SetInt("highscore9", 0);
        PlayerPrefs.SetInt("highscore10", 0);

        PlayerPrefs.SetString("highscorePseudo", ".....");
        PlayerPrefs.SetString("highscore2Pseudo", ".....");
        PlayerPrefs.SetString("highscore3Pseudo", ".....");
        PlayerPrefs.SetString("highscore4Pseudo", ".....");
        PlayerPrefs.SetString("highscore5Pseudo", ".....");
        PlayerPrefs.SetString("highscore6Pseudo", ".....");
        PlayerPrefs.SetString("highscore7Pseudo", ".....");
        PlayerPrefs.SetString("highscore8Pseudo", ".....");
        PlayerPrefs.SetString("highscore9Pseudo", ".....");
        PlayerPrefs.SetString("highscore10Pseudo", ".....");

        PlayerPrefs.Save();
    }
}
