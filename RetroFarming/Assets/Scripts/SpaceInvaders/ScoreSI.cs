using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreSI
{

   public static int GetHighScore(int index = 0)
    {
        switch (index)
        {
            case 0:
                return PlayerPrefs.GetInt("highscoreSI", 0);
            case 1:
                return PlayerPrefs.GetInt("highscoreSI2", 0);
            case 2:
                return PlayerPrefs.GetInt("highscoreSI3", 0);
            case 3:
                return PlayerPrefs.GetInt("highscoreSI4", 0);
            case 4:
                return PlayerPrefs.GetInt("highscoreSI5", 0);
            case 5:
                return PlayerPrefs.GetInt("highscoreSI6", 0);
            case 6:
                return PlayerPrefs.GetInt("highscoreSI7", 0);
            case 7:
                return PlayerPrefs.GetInt("highscoreSI8", 0);
            case 8:
                return PlayerPrefs.GetInt("highscoreSI9", 0);
            case 9:
                return PlayerPrefs.GetInt("highscoreSI10", 0);
            default: return PlayerPrefs.GetInt("highscoreSI", 0);
        }
    }

    public static string GetHighScorePseudo(int index = 0)
    {
        switch (index)
        {
            case 0:
                return PlayerPrefs.GetString("highscoreSIPseudo", "Utilisateur inconnu");
            case 1:
                return PlayerPrefs.GetString("highscoreSI2Pseudo", "Utilisateur inconnu");
            case 2:
                return PlayerPrefs.GetString("highscoreSI3Pseudo", "Utilisateur inconnu");
            case 3:
                return PlayerPrefs.GetString("highscoreSI4Pseudo", "Utilisateur inconnu");
            case 4:
                return PlayerPrefs.GetString("highscoreSI5Pseudo", "Utilisateur inconnu");
            case 5:
                return PlayerPrefs.GetString("highscoreSI6Pseudo", "Utilisateur inconnu");
            case 6:
                return PlayerPrefs.GetString("highscoreSI7Pseudo", "Utilisateur inconnu");
            case 7:
                return PlayerPrefs.GetString("highscoreSI8Pseudo", "Utilisateur inconnu");
            case 8:
                return PlayerPrefs.GetString("highscoreSI9Pseudo", "Utilisateur inconnu");
            case 9:
                return PlayerPrefs.GetString("highscoreSI10Pseudo", "Utilisateur inconnu");
            default: return PlayerPrefs.GetString("highscoreSIPseudo", "Utilisateur inconnu");
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
                PlayerPrefs.SetInt("highscoreSI", score);
                PlayerPrefs.SetString("highscoreSIPseudo", pseudo);
                break;
            case 1:
                PlayerPrefs.SetInt("highscoreSI2", score);
                PlayerPrefs.SetString("highscoreSI2Pseudo", pseudo);
                break;
            case 2:
                PlayerPrefs.SetInt("highscoreSI3", score);
                PlayerPrefs.SetString("highscoreSI3Pseudo", pseudo);
                break;
            case 3:
                PlayerPrefs.SetInt("highscoreSI4", score);
                PlayerPrefs.SetString("highscoreSI4Pseudo", pseudo);
                break;
            case 4:
                PlayerPrefs.SetInt("highscoreSI5", score);
                PlayerPrefs.SetString("highscoreSI5Pseudo", pseudo);
                break;
            case 5:
                PlayerPrefs.SetInt("highscore6SI", score);
                PlayerPrefs.SetString("highscoreSI6Pseudo", pseudo);
                break;
            case 6:
                PlayerPrefs.SetInt("highscoreSI7", score);
                PlayerPrefs.SetString("highscoreSI7Pseudo", pseudo);
                break;
            case 7:
                PlayerPrefs.SetInt("highscoreSI8", score);
                PlayerPrefs.SetString("highscoreSI8Pseudo", pseudo);
                break;
            case 8:
                PlayerPrefs.SetInt("highscoreSI9", score);
                PlayerPrefs.SetString("highscoreSI9Pseudo", pseudo);
                break;
            case 9:
                PlayerPrefs.SetInt("highscoreSI10", score);
                PlayerPrefs.SetString("highscoreSI10Pseudo", pseudo);
                break;
            default: break;
        }
        PlayerPrefs.Save();
    }

    public static void UpdateHighscore()
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
            Swap(indexToSwitch, score, PlayerPrefs.GetString("pseudo", "VOUS"));
        }

        PlayerPrefs.Save();
    }

    private static void ChangeVous(string pseudo)
    {
        for(int i=0; i<10; i++)
        {
            if(GetHighScorePseudo(i) == "VOUS")
            {
                SetHighScore(pseudo, i, GetHighScore(i));
            }
        }
        GameOverSI.ShowStaticUpdated();
    }

    public static void SetPseudo(string pseudo)
    {
        PlayerPrefs.SetString("pseudo", pseudo);
        ChangeVous(pseudo);
        PlayerPrefs.Save();
    }

    public static void SetScore(int score)
    {
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.SetString("pseudo", "VOUS");
        PlayerPrefs.Save();
    }

    public static void Swap(int index, int newscore, string pseudo)
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

    public static void ReInitialize()
    {
        PlayerPrefs.SetInt("highscoreSI", 0);
        PlayerPrefs.SetInt("highscoreSI2", 0);
        PlayerPrefs.SetInt("highscoreSI3", 0);
        PlayerPrefs.SetInt("highscoreSI4", 0);
        PlayerPrefs.SetInt("highscoreSI5", 0);
        PlayerPrefs.SetInt("highscoreSI6", 0);
        PlayerPrefs.SetInt("highscoreSI7", 0);
        PlayerPrefs.SetInt("highscoreSI8", 0);
        PlayerPrefs.SetInt("highscoreSI9", 0);
        PlayerPrefs.SetInt("highscoreSI10", 0);

        PlayerPrefs.SetString("highscoreSIPseudo", ".....");
        PlayerPrefs.SetString("highscoreSI2Pseudo", ".....");
        PlayerPrefs.SetString("highscoreSI3Pseudo", ".....");
        PlayerPrefs.SetString("highscoreSI4Pseudo", ".....");
        PlayerPrefs.SetString("highscoreSI5Pseudo", ".....");
        PlayerPrefs.SetString("highscoreSI6Pseudo", ".....");
        PlayerPrefs.SetString("highscoreSI7Pseudo", ".....");
        PlayerPrefs.SetString("highscoreSI8Pseudo", ".....");
        PlayerPrefs.SetString("highscoreSI9Pseudo", ".....");
        PlayerPrefs.SetString("highscoreSI10Pseudo", ".....");

        PlayerPrefs.Save();
    }
}